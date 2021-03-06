/*
 * Embedded solutions and SHIT - Software-Hardware Integration and Testing
 * Elektrotehnicki fakultet Sarajevo
 * Odsjek za automatiku i elektroniku
 * Praktikum automatike
 * 
 * Projektni zadatak: Sistem za narucivanje hrane u restoranu
 * File:    Predajnik main.c
 * Authors: Almir Besic
 *          Mirzet Brkic
 *          Semir Berkovic
 */
// PIC16F1939

#include <xc.h>
// CONFIG1
#pragma config FOSC = HS        // Oscillator Selection (HS Oscillator, High-speed crystal/resonator connected between OSC1 and OSC2 pins)
#pragma config WDTE = OFF       // Watchdog Timer Enable (WDT disabled)
#pragma config PWRTE = OFF      // Power-up Timer Enable (PWRT disabled)
#pragma config MCLRE = ON       // MCLR Pin Function Select (MCLR/VPP pin function is MCLR)
#pragma config CP = OFF         // Flash Program Memory Code Protection (Program memory code protection is disabled)
#pragma config CPD = OFF        // Data Memory Code Protection (Data memory code protection is disabled)
#pragma config BOREN = OFF      // Brown-out Reset Enable (Brown-out Reset disabled)
#pragma config CLKOUTEN = OFF   // Clock Out Enable (CLKOUT function is disabled. I/O or oscillator function on the CLKOUT pin)
#pragma config IESO = OFF       // Internal/External Switchover (Internal/External Switchover mode is disabled)
#pragma config FCMEN = OFF      // Fail-Safe Clock Monitor Enable (Fail-Safe Clock Monitor is disabled)

// CONFIG2
#pragma config WRT = OFF        // Flash Memory Self-Write Protection (Write protection off)
#pragma config VCAPEN = OFF     // Voltage Regulator Capacitor Enable (All VCAP pin functionality is disabled)
#pragma config PLLEN = OFF      // PLL Enable (4x PLL disabled)
#pragma config STVREN = OFF     // Stack Overflow/Underflow Reset Enable (Stack Overflow or Underflow will not cause a Reset)
#pragma config BORV = LO        // Brown-out Reset Voltage Selection (Brown-out Reset Voltage (Vbor), low trip point selected.)
#pragma config LVP = OFF        // Low-Voltage Programming Enable (High-voltage on MCLR/VPP must be used for programming)

// Frekvencija oscilatora
#define _XTAL_FREQ 8000000

// Pomocni makroi za pristup bitima varijable
#define testBit(var, bit) ((var) & (1 << (bit)))
#define setBit(var, bit) ((var) |= (1 << (bit)))
#define clrBit(var, bit) ((var) &= ~(1 << (bit)))

// Alijasi za komponente/pinove
#define DATA RC2    // Data pin RF predajnika
#define LED RD4     // Anoda LED 
#define RST RD3     // Reset pin RFID modula
#define IRQ RB0     // Interrupt pin RFID modula
#define SDI RC4     // SDI/MISO pin RFID modula
#define SDO RC5     // SDO/MOSI pin RFID modula
#define SCK RC3     // SCK pin RFID modula
#define SDA RD2     // SDA pin RFID modula

// Pomocne varijable
char t = 0;
char byteNo = 0;
char rf_data[2];
char pcData;
char send = 0;

void interrupt prekidna_rutina();

// Pomocne funkcije
void rf_send();
void init();
void init_serial();
void init_rf();

void main(void) {
    init();
    while(1){
    }
}

void interrupt prekidna_rutina(){
    if(TMR0IE && TMR0IF){
        TMR0 = 6;
        TMR0IF = 0;
        if(send == 1)
            rf_send();
        else t = 0;
    } else if (RCIE && RCIF) {
        pcData = RCREG;
        if(pcData == '*' || pcData == '#') {
            rf_data[0] = pcData;
            send = 0;
        }
        else {
            rf_data[1] = pcData;
            send = 1;
        }
        
    }
}

// Inicijalizacija pinova, RF modula, serijske komunikacije i prekida
void init(){
    TRISCbits.TRISC2 = 0;   // RC2 je izlazni [Data pin RF predajnika]
    DATA = 0;
    
    init_rf();
    init_serial();
    PEIE = 1;
    RCIE = 1;
    GIE = 1;
}

// Inicijalizacija TIMER0 [osnovni takt rf signala]
void init_rf(){
    T0CS = 0;
    T0SE = 1;
    PSA = 0; // PRESCALER 1:4
    PS2 = 0;
    PS1 = 0;
    PS0 = 1;
    TMR0 = 6;
    TMR0IE = 1;
}

// Funkcija za generisanje naponskog nivoa RF signala (manchester enkodiranja)
void rf_send(){
    // "zauzimanje" etera - 10 promjena 0->1->0
    if (t == 0) DATA = 1;
    else if (t < 10) DATA = !DATA;
    else if (t < 16) DATA = 1;   
    else if (t < 17)  DATA = 0;
    else {
        if (t%2 == 1){
            // Signal podatka
            if (testBit(rf_data[byteNo], (t - 17)/2)) DATA = 1;
            else DATA = 0;
        } else {
            // Diferencijalni signal
            if (testBit(rf_data[byteNo], (t - 17)/2)) DATA = 0;
            else DATA = 1;
        }
    }
    t++;
    // Kraj poruke
    if (t == 34){
        DATA = 0;
        t = 0;
        if(byteNo == 0) 
            byteNo = 1;
        else 
            byteNo = 0;
    }
}

// Inicijalizacija serijskog modula
void init_serial() {
    SPEN = 1;
    SYNC = 0;
    BRG16 = 0;
    BRGH = 1;
    SPBRGH = 0x00;
    SPBRGL = 51;
    CREN = 1;
    SREN = 1;
    TXEN = 1;
}

