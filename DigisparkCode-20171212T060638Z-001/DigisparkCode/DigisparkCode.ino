const int xPin = 1; //P2
const int analogOutPin = 1; //PWM, P1

int x;

void setup() 
{
  //if the analog pins are set to output we won't be able to read from them later
  //so we do this...
  pinMode(2, INPUT); //use digital pin no. here instead of analog pin no.
  pinMode(analogOutPin, OUTPUT); //this an analog out pin(PWM)
}

void loop() 
{
  x = analogRead(xPin); //these are using analog pin numbers
  analogWrite(analogOutPin, x/2);                                                                                                                   
}
