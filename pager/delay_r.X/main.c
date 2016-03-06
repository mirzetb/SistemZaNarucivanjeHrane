/*
 * File:   main.c
 * Author: mirzet brkic
 *
 * Created on February 5, 2016, 8:56 PM
 */


#include <xc.h>
#define _XTAL_FREQ 8000000
// CONFIG
#pragma config FOSC = HS        // Oscillator Selection bits (HS oscillator)
#pragma config WDTE = OFF       // Watchdog Timer Enable bit (WDT disabled)
#pragma config PWRTE = OFF      // Power-up Timer Enable bit (PWRT disabled)
#pragma config BOREN = OFF      // Brown-out Reset Enable bit (BOR disabled)
#pragma config LVP = OFF        // Low-Voltage (Single-Supply) In-Circuit Serial Programming Enable bit (RB3 is digital I/O, HV on MCLR must be used for programming)
#pragma config CPD = OFF        // Data EEPROM Memory Code Protection bit (Data EEPROM code protection off)
#pragma config WRT = OFF        // Flash Program Memory Write Enable bits (Write protection off; all program memory may be written to by EECON control)
#pragma config CP = OFF         // Flash Program Memory Code Protection bit (Code protection off)

#define testBit(var, bit) ((var) & (1 << (bit)))
#define setBit(var, bit) ((var) |= (1 << (bit)))
#define clrBit(var, bit) ((var) &= ~(1 << (bit)))

#define DATA RB0

void init_regs();
//void send_to_pc(char pod);

//void interrupt prekidna_rutina();
void interrupt prekidna_rutina();

char i = 0;
char podatak = 0x00;
char kom = 0;
char visoko = 0;

void main(void) {
    init_regs();
    while(1)
    {
    }
    return;
}

void init_regs()
{
    // INT
    TRISBbits.TRISB0 = 1;
    GIE = 1;
    INTE = 1;
    INTEDG = 1;
    
    /*
    // TIMER0 
    T0CS = 0; // Interni clock
    PSA = 0;  // Prescaler za TMR0
    PS2 = 0;  // Prescaler 1:8
    PS1 = 1;
    PS0 = 0;
    */
    BRGH = 1;
    SPBRG = 51;
    SYNC = 0;
    SPEN = 1;
    TXEN = 1;
    TRISD = 0x00;
    PORTD = 0xFF;    
}


void interrupt prekidna_rutina()
{
    if (INTE && INTF)
    {
        INTF = 0;
        
        for (i = 0; i < 100; i++)
        {
            __delay_us(20);
            if (DATA == 0) return;
        }
        
        while(DATA == 1);
        __delay_us(1050);
        
        for(i = 0; i < 8; i++)
        {
            if(DATA == 1)
                setBit(podatak, i);
            else
                clrBit(podatak, i);
            __delay_us(1000);
        }

        if (podatak == '#')
        TXREG = 0x0A;
        else
        TXREG = podatak;
         
        
    }
    else if (TMR0IE && TMR0IF)
    {
        TMR0IF = 0;
       // TMR0 = 6;
        i++;
        if (i < 8)
        {
            if (DATA == 1) setBit(podatak, i);
            else clrBit(podatak, i);
        }
        else
        {
            PORTD = 0xF0;
            i = 0;
            INTE = 1;
            TMR0IE = 0;
        
            for (i = 0; i < 8; i++)
            {
                TXREG = testBit(podatak, i) + '0';
                __delay_us(50);
            }
            i = 0;
       /* if (podatak == '#')
        TXREG = 0x0A;
        else
        TXREG = podatak;*/
        }
    }
}

void send_to_pc(char pod)
{
    TXREG = pod;
}