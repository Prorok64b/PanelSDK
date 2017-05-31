String input = "";
int Btns[] = {51,39,40,42,46,44,41,43,45,47,49,38,11,10,2,13,12,3,4,6};
int Lights[] = {24,22,35,33,34,36,32,26,28,29,27,25,23};

void Init(){
  for(int i = 0; i < sizeof(Btns); i++){
    pinMode(Btns[i],INPUT_PULLUP);
  }  

  for(int i = 0; i < sizeof(Lights); i++){
    pinMode(Lights[i],OUTPUT);
  }  
}

void ActiveLights(boolean check){
  if(check){
    for(int i = 0; i < sizeof(Lights); i++){
      digitalWrite(Lights[i], HIGH);
    }
  }else{
    for(int i = 0; i < sizeof(Lights); i++){
      digitalWrite(Lights[i], LOW);
    }  
  }
}

void ActiveLight(int pin, boolean check){
   if(check){
      digitalWrite(pin, HIGH);
    }else{
      digitalWrite(pin, LOW);
  }
}

// the setup function runs once when you press reset or power the board
void setup() {
  // initialize digital pin LED_BUILTIN as an output.
  Serial.begin(9600);
  Serial.setTimeout(25);
  
  Init();
  ActiveLights(false);
}

// the loop function runs over and over again forever
void loop() {
  input = Serial.readString();
  
//  Serial.println(input);
    if(input[0] == '0'){  //  Check button for Up
      int btn = input.substring(2,sizeof(input) - 1).toInt();
      
      if(digitalRead((int)btn) == HIGH){
        Serial.println("/y");
      }else{
        Serial.println("/n");
      }
    }
  
    if(input[0] == '1'){  //  Check button for Down
      int btn = input.substring(2,sizeof(input) - 1).toInt();
      
      if(digitalRead((int)btn) == LOW){
        Serial.println("/y");
      }else{
        Serial.println("/n");
      }
    }
  
    if(input[0] == '2'){  //  On Light
      int light = input.substring(2,sizeof(input) - 1).toInt();
      ActiveLight((int)light, true);
  
      Serial.println("/yP");
    }
  
    if(input[0] == '3'){  //  Off Light
      int light = input.substring(2,sizeof(input) - 1).toInt();
      ActiveLight((int)light, false);
  
      Serial.println("/nP");
    }
  
    if(input[0] == '4'){  // Off all Lights
      ActiveLights(false);
  
      Serial.println("/nL");
    }
  
    if(input[0] == '5'){  // On all Lights
      ActiveLights(true);
  
      Serial.println("/yL");
    }
}

