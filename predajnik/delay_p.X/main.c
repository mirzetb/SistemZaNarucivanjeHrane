/*
 * File:   main.c
 * Author: mirzet brkic
 *
 * Created on February 5, 2016, 8:42 PM
 */


#include <xc.h>
#define _XTAL_FREQ 8000000

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

#define testBit(var, bit) ((var) & (1 << (bit)))
#define setBit(var, bit) ((var) |= (1 << (bit)))
#define clrBit(var, bit) ((var) &= ~(1 << (bit)))

#define DATA RC2

void init_regs();
void init_comm();

void rf_send(char podatak);
char podatak;

void main(void) {
    init_regs();
    while(1)
    {
        
        rf_send('P');
        rf_send('O');
        rf_send('K');
        rf_send('U');
        rf_send('S');
        rf_send('A');
        rf_send('J');
        rf_send(' ');
        rf_send('K');
        rf_send('O');
        rf_send('M');
        rf_send('U');
        rf_send('N');
        rf_send('I');
        rf_send('K');
        rf_send('A');
        rf_send('C');
        rf_send('I');
        rf_send('J');
        rf_send('E');
        rf_send('#');
        __delay_ms(5000);
        /*
        if(RCIF)
        {
            podatak = RCREG;
            rf_send(podatak);
        }*/
    }
}

void init_regs()
{
    TRISCbits.TRISC2 = 0;
    DATA = 0;
    init_comm();
}

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
    __delay_us(500);
    
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
}

void init_comm()
{
    BRG16 = 0;
    BRGH = 0;
    SPBRGH = 0;
    SPBRGL = 12;
    
    SYNC = 0;
    SPEN = 1;
    TXEN = 1;
    CREN = 1;
}