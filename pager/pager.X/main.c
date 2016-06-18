/*
 * Embedded solutions and SHIT - Software-Hardware Integration and Testing
 * Elektrotehnicki fakultet Sarajevo
 * Odsjek za automatiku i elektroniku
 * Praktikum automatike
 * 
 * Projektni zadatak: Sistem za narucivanje hrane u restoranu
 * File:    Pager main.c
 * Authors: Almir Besic
 *          Mirzet Brkic
 *          Semir Berkovic
 */

// PIC16F877A
#include <xc.h>

// CONFIG
#pragma config FOSC = HS        // Oscillator Selection bits (HS oscillator)
#pragma config WDTE = OFF       // Watchdog Timer Enable bit (WDT disabled)
#pragma config PWRTE = OFF      // Power-up Timer Enable bit (PWRT disabled)
#pragma config BOREN = OFF      // Brown-out Reset Enable bit (BOR disabled)
#pragma config LVP = OFF        // Low-Voltage (Single-Supply) In-Circuit Serial Programming Enable bit (RB3 is digital I/O, HV on MCLR must be used for programming)
#pragma config CPD = OFF        // Data EEPROM Memory Code Protection bit (Data EEPROM code protection off)
#pragma config WRT = OFF        // Flash Program Memory Write Enable bits (Write protection off; all program memory may be written to by EECON control)
#pragma config CP = OFF         // Flash Program Memory Code Protection bit (Code protection off)

// Frekvencija oscilatora
#define _XTAL_FREQ 8000000

// Pomocni makroi za pristup bitima varijable
#define testBit(var, bit) ((var) & (1 << (bit)))
#define setBit(var, bit) ((var) |= (1 << (bit)))
#define clrBit(var, bit) ((var) &= ~(1 << (bit)))

// Alijasi za komponente/pinove
#define VIB RA5     // Vibrator
#define BUZZ RC3    // Buzzer
#define DATA RB0    // Data pin RF prijemnika
#define D1 RD0      // Katoda RGB diode 1
#define D2 RD1      // Katoda RGB diode 2
#define D3 RD2      // Katoda RGB diode 3
#define D4 RD3      // Katoda RGB diode 4
#define BLUE RD6    // B pin RGB dioda
#define GREEN RD5   // G pin RGB dioda
#define RED RD4     // R pin RGB dioda
#define BAT RA0     // Napon baterije

// Stanje debuggera/komunikacije sa PC-om
#define DEBUG 1

// Identifikacija pagera
char pagerID = 'K';
char opsegID;
char rf_data[2] = {0x00, 0x00};

// Pomocne vrijable
char play = 0;
char t = 0;
char loop = 0;
char visoko = 0;
char prijem = 0;
char i = 0;
char kod = 0;
char kodKraj = 0;
char brojacLED = 0;
char brojacVIB = 0;

// Stanja pagera
enum {CEKANJE, PROZVAN, IZVANOPSEGA} STANJE;
// Stanja baterije
enum {PRAZNA, NIJEPRAZNA} BATERIJA;
 
// Init metode
void init();
void init_analog();
void init_buzz();
void init_batt();
void init_rf();
void init_debug();

// Pmocne metode
void led_show();
void noPrijem();
void Prijem();

// Prekidna metoda
void interrupt prekidna_rutina();


void main(void){
    init();
    while(1) {
        if (STANJE == PROZVAN){
            RED = 0;
            GREEN = 1;
            BLUE = 0;
            if (play == 1){
                BUZZ = 1;
                __delay_ms(1);
                BUZZ = 0;
                __delay_ms(1);
            }
        } else if (STANJE == IZVANOPSEGA){
            RED = 1;
            GREEN = 0;
            BLUE = 0;
            //-- drugi ton?
            if (play == 1){
                BUZZ = 1;
                __delay_ms(1);
                BUZZ = 0;
                __delay_ms(1);
            }
        } else if (STANJE == CEKANJE){
            if (BATERIJA == PRAZNA){
                RED = 1;
                GREEN = 0;
                BLUE = 0;

                D1 = 0;
                D2 = 0;
                D3 = 0;
                D4 = 0;
            } else {
                RED = 0;
                GREEN = 0;
                BLUE = 0;

                D1 = 1;
                D2 = 1;
                D3 = 1;
                D4 = 1;
            } 
        }   
    } 
}

void interrupt prekidna_rutina(){
    if(TMR2IE && TMR2IF){
        TMR2IF = 0;
        brojacLED++;
        if(brojacLED == 250){
            brojacLED = 0;
            brojacVIB++;
            if (STANJE == PROZVAN || STANJE == IZVANOPSEGA){
                led_show();
                if(brojacVIB == 2){
                    play = 1;
                    VIB = 0;
                }
                if(brojacVIB == 5){
                    VIB = 1;
                    brojacVIB = 0;
                    play = 0;
                }
            }
        }
    } else if (INTE && INTF){
        // Prva uzlazna ivica -> Omogucavanje TMR0
        INTE = 0;
        INTF = 0;
        
        TMR0IE = 1;
        TMR0IF = 0;
    } else if (TMR0IE && TMR0IF){
        TMR0IF = 0;
        if (prijem == 0) noPrijem();
        else Prijem();    
    } else if (TMR1IE && TMR1IF){
        TMR1IF = 0;
        loop++;
        if (loop == 37){
            if (opsegID == 0x00)
                STANJE = IZVANOPSEGA;
            else {
                STANJE = CEKANJE;
                opsegID = 0x00;
            }
            loop = 0;
            GO = 1;
        }
    } else if (ADIE && ADIF){
        ADIF = 0;
        if (ADRESH > 60) BATERIJA = PRAZNA;
        else BATERIJA = NIJEPRAZNA;
    }
}

void noPrijem(){
    TMR0 = 206;
    if(DATA == 1){
       visoko++;
       if (visoko == 13){
         visoko = 0;
         INTE = 1;
         INTF = 0;

         INTEDG = 0;

         TMR0IE = 0;
         prijem = 1;
       }
   } else {
       visoko = 0;
       TMR0IE = 0;
       INTE = 1;
       INTF = 0;
       INTEDG = 1;
    }  
}

void Prijem(){
    TMR0 = 6;
    TMR0IF = 0;
    char k = 0;

    if(rf_data[0] == 0x00) k = 0;
    else k = 1;

    if(DATA == 1) setBit(rf_data[k], i);
    else clrBit(rf_data[k], i);
    i++;
    if(i == 8){
        i = 0;
        prijem = 0;
        INTE = 1;
        INTF = 0;
        INTEDG = 1;
        TMR0IE = 0;

        if(DEBUG == 1){
            TXREG = rf_data[k];
        }
        
        if (k == 1){
            if(rf_data[0] == '*' && rf_data[1] == pagerID) kod++;
            else kod = 0;

            if(rf_data[0] == '#' && rf_data[1] == pagerID) kodKraj++;
            else kodKraj = 0;

            if(kod == 3 && STANJE == CEKANJE) STANJE = PROZVAN;
            if(kodKraj == 2 && STANJE == PROZVAN) STANJE = CEKANJE;

            rf_data[0] = 0x00;
            rf_data[1] = 0x00;
        }
    }
}

// Inicijalizacija stanja, usmjerenja pinova, pocetnog stanja pinova,
// AD konvertora, timera i prekida
void init() {
    // Pocetno stanje
    STANJE = CEKANJE;
    
    // Pocetno stanje baterije
    BATERIJA = NIJEPRAZNA;
    
    // Usmjerenja pinova
    TRISD = 0x00;           // PORTD je izlazni [RGB diode]
    TRISAbits.TRISA0 = 1;   // RA0 je ulazni [Napon baterije]
    TRISAbits.TRISA5 = 0;   // RA5 je izlazni [Vibrator]
    TRISCbits.TRISC3 = 0;   // RC2 je izlazni [Buzzer]
    TRISBbits.TRISB0 = 1;   // RB0 je ulazni [Data pin RF prijemnika]
    
    // Pocetna stanja pinova
    // Sve diode ugasene, nema boje
    D1 = 1;
    D2 = 1;
    D3 = 1;
    D4 = 1;
    RED = 0;
    GREEN = 0;
    BLUE = 0;
    
    VIB = 0;    // Vibrator iskljucen
    BUZZ = 0;   // Buzzer iskljucen
    
    // Inicijalizacija modula
    init_analog();
    init_buzz();
    init_batt();
    init_rf();
    PEIE = 1;
    GIE = 1;
    if (DEBUG == 1)
        init_debug();
}

//  Inicijalizacija AD konvertora
void init_analog() {
    ADFM = 0;   // Lijevo poravnavanje rezultata
   
    PCFG3 = 1;  // RA0 analogni, RA1-7 digitalni
    PCFG2 = 1;  // Vref+ = Vdd, Vref- = Vss
    PCFG1 = 1;
    PCFG0 = 0;
    
    CHS2 = 0;   // Channel 0 (AN0)
    CHS1 = 0;
    CHS0 = 0;

    ADCS2 = 1;  // Interni RC oscilator
    ADCS1 = 1;
    ADCS0 = 1;
    
    ADON = 1;   // Ukljuivanje modula
    ADIE = 1;
}

// Inicijalizacija TIMER2 modula 
void init_buzz() {  
    T2CKPS1 = 1;    // Prescale 1:16
    T2CKPS0 = 1;
    
    PR2 = 125;
    TMR2ON = 1;     // Ukljucivanje Timer 2
    TMR2IE = 1;
}

// Inicijalizacija TIMER1 modula [Indikacija baterije, izlazka iz opsega]
void init_batt() {
    T1CKPS1 = 1; // Prescaler 1:8
    T1CKPS0 = 1;
    
    T1OSCEN = 0;
    TMR1CS = 0;
    
    TMR1ON = 1;
    TMR1IE = 1;
}

// Inicijalizacija Timer 0 modula [RF komunikacija]
void init_rf() {
    T0CS = 0;
    
    PSA = 0;    // Prescaler 1:8
    PS2 = 0;
    PS1 = 1;
    PS0 = 0;
}

// Inicijalizacija serijske komunikacije sa PC-om
void init_debug() {
    BRGH = 1;
    SPBRG = 51;
    SYNC = 0;
    SPEN = 1;
    TXEN = 1;
}

// LED rotacija
void led_show() {
    if (D1 == 0) {
        D1 = 1;
        D2 = 0;
    } else if(D2 == 0) {
        D2 = 1;
        D3 = 0;
    } else if(D3 == 0) {
        D3 = 1;
        D4 = 0;
    } else {
        D4 = 1;
        D1 = 0;
    }
}