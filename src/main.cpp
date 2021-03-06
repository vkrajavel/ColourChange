#include <Arduino.h>
#include <FastLED.h>


// usually the rotary encoders three pins have the ground pin in the middle
enum PinAssignments {
encoderPinA = 2,   // right (labeled DT on our decoder, yellow wire)
encoderPinB = 3,   // left (labeled CLK on our decoder, green wire)
clearButton = 8    // switch (labeled SW on our decoder, orange wire)
// connect the +5v and gnd appropriately
};

volatile unsigned int encoderPos = 0;  // a counter for the dial
unsigned int lastReportedPos = 1;   // change management
static boolean rotating=false;      // debounce management

// interrupt service routine vars
boolean A_set = false;
boolean B_set = false;

#define PIN 4
#define LED_COUNT 30


CRGBArray<LED_COUNT> leds;

CRGB current_colour;
boolean change[3];
boolean off = false;

void doEncoderA();
void doEncoderB();
void makeColorGradient(float frequency1, float frequency2, float frequency3,
                           int phase1, int phase2, int phase3);
boolean numcheck(int R, int G, int B);

void setup() {

FastLED.addLeds<NEOPIXEL, PIN>(leds, LED_COUNT);

pinMode(encoderPinA, INPUT_PULLUP); // new method of enabling pullups
pinMode(encoderPinB, INPUT_PULLUP);
pinMode(clearButton, INPUT_PULLUP);
// turn on pullup resistors (old method)
//digitalWrite(encoderPinA, HIGH);
// digitalWrite(encoderPinB, HIGH);
// digitalWrite(clearButton, HIGH);

// encoder pin on interrupt 0 (pin 2)
attachInterrupt(0, doEncoderA, CHANGE);
// encoder pin on interrupt 1 (pin 3)
attachInterrupt(1, doEncoderB, CHANGE);

Serial.begin(9600);  // output

change[0] = true;
change[1] = false;
change[2] = false;
current_colour = CRGB::Black;
leds.fill_solid(current_colour);
FastLED.show();
}

// main loop, work is done by interrupt service routines, this one only prints stuff
void loop() {
rotating = true;  // reset the debouncer

if (lastReportedPos != encoderPos) {
  lastReportedPos = encoderPos;

  leds.fill_solid(current_colour);
  char sendColour[20];
  sprintf(sendColour,"%d,%d,%d \n",current_colour.r,current_colour.g,current_colour.b);
  Serial.print(sendColour);
  Serial.flush();
  FastLED.show();
}

if (digitalRead(clearButton) == LOW )  {
  //debounce
  if(off){
    leds.fill_solid(current_colour);
    off = false;
  }else{
    leds.fill_solid(CRGB::Black);
    off = true;
  }
  FastLED.show();
  delay(200);
}

if(Serial.available() > 0)
  {
      int check = Serial.parseInt();
      int R =  Serial.parseInt();
      int G =  Serial.parseInt();
      int B =  Serial.parseInt();
      if (check == 5000 && numcheck(R,G,B)){
        current_colour.r = R;
        current_colour.g = G;
        current_colour.b = B;
        leds.fill_solid(current_colour);
        Serial.flush();
        FastLED.show();
        char sendColour[20];
        sprintf(sendColour,"%d,%d,%d \n",current_colour.r,current_colour.g,current_colour.b);
        Serial.print(sendColour);
        Serial.flush();
      }
      if (check == 5010){
        leds.fill_rainbow(50);
        Serial.flush();
        FastLED.show();
        Serial.print(F("Rainbow"));
        Serial.flush();
      }
  }
}

// Interrupt on A changing state
void doEncoderA(){
// debounce
if ( rotating ) delay (1);  // wait a little until the bouncing is done

// Test transition, did things really change?
if( digitalRead(encoderPinA) != A_set ) {  // debounce once more
  A_set = !A_set;

  // adjust counter + if A leads B
  if ( A_set && !B_set ){
    makeColorGradient(0.1,0.2,0.3,0,0,0);
    encoderPos += 1;
  }

  rotating = false;  // no more debouncing until loop() hits again
}
}

// Interrupt on B changing state, same as A above
void doEncoderB(){
if ( rotating ) delay (1);
if( digitalRead(encoderPinB) != B_set ) {
  B_set = !B_set;
  //  adjust counter - 1 if B leads A
  if( B_set && !A_set ){
    makeColorGradient(0.1,0.2,0.3,0,0,0);
    encoderPos -= 1;
  }

  rotating = false;
}
}

void makeColorGradient(float frequency1, float frequency2, float frequency3,
                           int phase1, int phase2, int phase3)
{
 int center = 128;
 int width = 127;
 current_colour.r = sin8(frequency1*encoderPos + phase1) * width + center;
 current_colour.g = sin8(frequency2*encoderPos + phase2) * width + center;
 current_colour.b = sin8(frequency3*encoderPos + phase3) * width + center;
}

boolean numcheck(int R, int G, int B){
if(R < 0 || R > 255 || G < 0 || G > 255 || B < 0 || B > 255 )
  return false;
return true;
}
