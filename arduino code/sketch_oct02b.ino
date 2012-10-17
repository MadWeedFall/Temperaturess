int potPin = 0;                     //设置模拟口4为LM35的信号输入端口
float temperature = 0;                //设置temperature为浮点变量
long val=0;                       //设置val为长整数变量
 
void setup()
{
Serial.begin(9600);//设置波特率
}
 
void loop ()                     
{
   val=analogRead(potPin);//温度传感器LM35接到模拟PIN4上；val变量为从LM35信号口读取到的数值
  temperature = (val*0.0048828125*100);   //把读取到的val转换为温度数值,系数一：0.00488125=5/1024,0~5V对应模拟口读数1~1024,系数二：100=1000/10,1000是毫伏与伏的转换；10是每10毫伏对应一度温升。
   //Serial.print("Tep=  ");
   Serial.print(temperature);
   Serial.println(" ");
   delay(500);//延时500毫秒，这里也就是刷新速度。
 
}
