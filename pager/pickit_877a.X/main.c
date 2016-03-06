/*
 * File:   main.c
 * Author: mirzet brkic
 *
 * Created on January 16, 2016, 10:55 PM
 */


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
#define _XTAL_FREQ 8000000

#define testBit(var, bit) ((var) & (1 << (bit)))
#define setBit(var, bit) ((var) |= (1 << (bit)))
#define clrBit(var, bit) ((var) &= ~(1 << (bit)))

#define KASNJENJE 1000

#define DATA  RD0 

void diode_test();
void vibrator_test();
void buzzer_test();

void init_regs();
void interrupt prekidna_rutina();

void main(void) {
    init_regs();
    while(1){}
}

void interrupt prekidna_rutina()
{
    if(TMR0IE && TMR0IF)
    {
        TMR0IF = 0;
        TMR0 = 156;
        DATA = !DATA;
    }
    
}
void init_rf()
{
    T0CS = 0;
    
    PSA = 0;    // Prescaler 1:8
    PS2 = 0;
    PS1 = 1;
    PS0 = 0;
    
    GIE = 1;
    TMR0IE = 1;
}

void init_regs()
{
    TRISD = 0x00;
    init_rf();
   /**
    PORTD = 0xF0;
    TRISA= 0x00;
    TRISCbits.TRISC2 = 0;
    /*
    PCFG3 = 1;  // RA0 analogni, RA1-7 digitalni
    PCFG2 = 1;  // Vref+ = Vdd, Vref- = Vss
    PCFG1 = 1;
    PCFG0 = 0;
*/
    
}

void diode_test()
{
    while (1)
    {
        RD6 = 1;
        RD0 = 0;
        RD3 = 1;
        __delay_ms(KASNJENJE);
        
        RD0 = 1;
        RD1 = 0;
        __delay_ms(KASNJENJE);
        
        RD1 = 1;
        RD2 = 0;
        __delay_ms(KASNJENJE);
        
        RD2 = 1;
        RD3 = 0;
        __delay_ms(KASNJENJE);
        
        RD5 = 1;
        RD6 = 0;
        RD0 = 0;
        RD3 = 1;
        __delay_ms(KASNJENJE);
        
        RD0 = 1;
        RD1 = 0;
        __delay_ms(KASNJENJE);
        
        RD1 = 1;
        RD2 = 0;
        __delay_ms(KASNJENJE);
        
        RD2 = 1;
        RD3 = 0;
        __delay_ms(KASNJENJE);
    
        
        RD5 = 0;
        RD4 = 1;
        RD0 = 0;
        RD3 = 1;
        __delay_ms(KASNJENJE);
        
        RD0 = 1;
        RD1 = 0;
        __delay_ms(KASNJENJE);
        
        RD1 = 1;
        RD2 = 0;
        __delay_ms(KASNJENJE);
        
        RD2 = 1;
        RD3 = 0;
        __delay_ms(KASNJENJE);
        RD4 = 0;
    }
}

void vibrator_test()
{
    while (1)
    {
        RA5 = 1;
        __delay_ms(1000);
        RA5 = 0;
        __delay_ms(1000);
    }
}

void buzzer_test()
{
    while (1)
    {
        RC2 = 1;
        __delay_us(500);
        RC2 = 0;
        __delay_us(500);
    }
}