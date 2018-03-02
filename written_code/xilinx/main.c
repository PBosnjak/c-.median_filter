/*
 * Copyright (c) 2009-2012 Xilinx, Inc.  All rights reserved.
 *
 * Xilinx, Inc.
 * XILINX IS PROVIDING THIS DESIGN, CODE, OR INFORMATION "AS IS" AS A
 * COURTESY TO YOU.  BY PROVIDING THIS DESIGN, CODE, OR INFORMATION AS
 * ONE POSSIBLE   IMPLEMENTATION OF THIS FEATURE, APPLICATION OR
 * STANDARD, XILINX IS MAKING NO REPRESENTATION THAT THIS IMPLEMENTATION
 * IS FREE FROM ANY CLAIMS OF INFRINGEMENT, AND YOU ARE RESPONSIBLE
 * FOR OBTAINING ANY RIGHTS YOU MAY REQUIRE FOR YOUR IMPLEMENTATION.
 * XILINX EXPRESSLY DISCLAIMS ANY WARRANTY WHATSOEVER WITH RESPECT TO
 * THE ADEQUACY OF THE IMPLEMENTATION, INCLUDING BUT NOT LIMITED TO
 * ANY WARRANTIES OR REPRESENTATIONS THAT THIS IMPLEMENTATION IS FREE
 * FROM CLAIMS OF INFRINGEMENT, IMPLIED WARRANTIES OF MERCHANTABILITY
 * AND FITNESS FOR A PARTICULAR PURPOSE.
 *
 */

/*
 * helloworld.c: simple test application
 *
 * This application configures UART 16550 to baud rate 9600.
 * PS7 UART (Zynq) is not initialized by this application, since
 * bootrom/bsp configures it to baud rate 115200
 *
 * ------------------------------------------------
 * | UART TYPE   BAUD RATE                        |
 * ------------------------------------------------
 *   uartns550   9600
 *   uartlite    Configurable only in HW design
 *   ps7_uart    115200 (configured by bootrom/bsp)
 */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "platform.h"
#include "xparameters.h"
#include "xbasic_types.h"
#include "xuartlite_l.h"
#include "xgpio.h"

int main()
{
while(1){
    init_platform();
    u32 m = 1;
    u32 n = 1;
    u32 i = 0;
    u32 j = 0;
    u32 l = 0;

    u8 flag=0;
    u32 adresa,adresa2;
    adresa = XPAR_MICRON_RAM_MEM0_BASEADDR;
    u32 addUART= XPAR_UARTLITE_1_BASEADDR;

    u32 rows, columns;
    u32 data;
    u8 data1,data2,data3;
    u32 data11;

    data1 = XUartLite_RecvByte(addUART);
    data2 = XUartLite_RecvByte(addUART);
    data3 = XUartLite_RecvByte(addUART);
    columns=(data1-'0')*100+(data2-'0')*10+(data3-'0');
    data1 = XUartLite_RecvByte(addUART);
    data2 = XUartLite_RecvByte(addUART);
    data3 = XUartLite_RecvByte(addUART);
    rows=(data1-'0')*100+(data2-'0')*10+(data3-'0');


    i=0;
    flag=0;
    adresa = XPAR_MICRON_RAM_MEM0_BASEADDR;
    adresa2 = XPAR_MICRON_RAM_MEM0_BASEADDR + (rows * columns * 4) + 4;


    for(i=0;i<rows*columns;i++){
   		 data = XUartLite_RecvByte(addUART);
   		 Xil_Out32LE(adresa, data);
   		 Xil_Out32LE(adresa2, data);
   		 adresa+=4;
   		 adresa2+=4;
	 }

	if(i==rows*columns) flag=1;
	adresa = XPAR_MICRON_RAM_MEM0_BASEADDR;
	adresa2 = XPAR_MICRON_RAM_MEM0_BASEADDR + (rows * columns * 4) + 4;

	if(flag==1){

	    for ( m = 1; m < rows - 1; ++m)
	      for ( n = 1; n < columns - 1; ++n)
	      {	        
	         int k = 0;
	         int window[9];
	         for ( j = m - 1; j < m + 2; ++j)
	            for ( i = n - 1; i < n + 2; ++i)
	               window[k++] = Xil_In32LE((adresa+(4*(j*columns+i))));
	         
	         for ( j = 0; j < 5; ++j)
	         {
	            int min = j;
	            for ( l = j + 1; l < 9; ++l)
	            if (window[l] < window[min])
	               min = l;
	            const int temp = window[j];
	            window[j] = window[min];
	            window[min] = temp;
	         }

	         Xil_Out32LE((adresa2+(4*(m * columns + n))), window[4]);
	      };




	    flag=2;

	}

	if(n>rows-3 && m>columns-3) flag=2;
	adresa = XPAR_MICRON_RAM_MEM0_BASEADDR;
	adresa2 = XPAR_MICRON_RAM_MEM0_BASEADDR + (rows * columns * 4) + 4;

	if(flag==2){
			for(i=0;i<rows*columns;i++){
				data11 = Xil_In32LE(adresa2);
				XUartLite_SendByte(addUART,data11);
				adresa2+=4;
			}
			flag = 0;
			m = 0;
			n = 0;
			i = 0;
	}
}
return 0;
}
