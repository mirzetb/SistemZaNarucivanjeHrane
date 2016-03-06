/*
 * Embedded solutions and SHIT - Software & hardware integration and testing
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

// PIC16F19393

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

char pageri[10] = {'P', 'A', 'G', 'E', 'R', 'I', '.', '.', '.', '#'};
char t = 0;
char slanje = 1;
char i = 0;
char pod = 'A';

void init();
void init_pc();
void init_rfid();
void init_interrupts();

void interrupt prekidna_rutina();
//void rf_send(char podatak);
void rf_send();
void rf_send2(char podatak);

void main(void) {
    init();
    while(1)
    {
       // rf_send2('O');
        //__delay_ms(1000);
    }
    return;
}

void interrupt prekidna_rutina()
{
    if (TMR0IE && TMR0IF)
    {
        TMR0IF = 0;
        TMR0 = 6;
        
        if (slanje == 1) rf_send();
        
        
    }

}


void rf_send()
{
    if (t == 0) DATA = 1;
    else if (t < 10) DATA = !DATA;
    else if (t < 16) DATA = 1;   
    else if (t < 17)  DATA = 0;
    else 
    {
        if (t%2 == 1)
        {
            if (testBit(pod, (t - 17)/2)) DATA = 1;
            else DATA = 0;
        }
        else
        {
            if (testBit(pod, (t - 17)/2)) DATA = 0;
            else DATA = 1;
        }
    }
    t++;
    if (t == 34)
    {
        DATA = 0;
        t = 0;
        __delay_ms(1000);
        pod++;
        if (pod > 'z') pod = 'A';
        /*
        i++;
        if (i == 10) 
        {
            i = 0;
            GIE = 0;
            __delay_ms(5000);
            GIE = 1;
            TMR0IF = 0;
        }*/
    }
}

void init()
{
    TRISCbits.TRISC2 = 0;   // RC2 je izlazni [Data pin RF predajnika]
    DATA = 1;
    
    init_interrupts();
}

void init_interrupts()
{
    GIE = 1;
    
    // TMR0
    T0CS = 0;
    T0SE = 1;
    PSA = 0; // PRESCALER 1:4
    PS2 = 0;
    PS1 = 0;
    PS0 = 1;
    TMR0IE = 1;
}

/*
void rf_send(char podatak)
{
    char i;
    for (i = 0; i < 5; i++)
    {
        DATA = 1;
        __delay_us(500);
        DATA = 0;
        __delay_us(500);
    }
    
    DATA = 1;
    __delay_us(3000);
    DATA = 0;
    __delay_us(1000);
    
    for (i = 0; i < 8; i++)
    {
        if (testBit(podatak, i))
            DATA = 1;
        else
            DATA = 0;
        __delay_us(500);
        
        if (testBit(podatak, i))
            DATA = 0;
        else
            DATA = 1;
        __delay_us(500);
    }

    DATA = 0;
}*/

/*
void rf_send2(char podatak)
{
    DATA = 0;
    __delay_us(5750);
    
     for (i = 0; i < 8; i++)
    {
        if (testBit(podatak, i))
            DATA = 1;
        else
            DATA = 0;
        __delay_us(500);
        
        if (testBit(podatak, i))
            DATA = 0;
        else
            DATA = 1;
        __delay_us(500);
    }
    DATA = 1;
}
 * */