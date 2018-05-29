
void setup()
{
  Serial.begin(115200);
  pinMode(8,INPUT);
  pinMode(9,INPUT);
  pinMode(10,INPUT);
  pinMode(11,INPUT);
}

void loop()
{
  int t;
  static float v[4]={0};
  for(int i=0; i<4; i++)
  {
    v[i] = pulseIn(8+i,HIGH,40200)*0.2f+v[i]*0.8f;
    int b = map(v[i],1000,1300,0,63);
    if(b>63) b=63;
    if(b<0) b=0;
    b = b | (i<<6);
    //Serial.write((char)b);
    Serial.print("player ");
    Serial.print(i); 
    Serial.print("= ");
    Serial.print(b);
    Serial.print('\n');
    delay(10);
  }
}

