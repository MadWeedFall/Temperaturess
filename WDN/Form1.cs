using System;
using System.Windows.Forms;
using System.IO.Ports;
using NetDimension.Weibo;

namespace WDN
{
    public partial class Form1 : Form
    {
        string appKey;
        string appSecret;
        string accessToken;
        Client sina;
        bool serialReadFlag;
        string temperature;

        public Form1()
        {
            InitializeComponent();

            appKey = Properties.Settings.Default.AppKey;
            appSecret = Properties.Settings.Default.AppSecret;
            accessToken = Properties.Settings.Default.AcessToken;
            serialReadFlag = false;

            OAuth oauth = null;
            sina = null;
            if (string.IsNullOrEmpty(accessToken))//如果本地未保存accessToken，这里没有做过期判断2012-10-5
            {
                oauth = Authorize();
                if (!string.IsNullOrEmpty(oauth.AccessToken))
                {
                    Properties.Settings.Default.AcessToken = oauth.AccessToken;
                    Properties.Settings.Default.Save();
                    statTxt.Text = "授权成功，保存accesstoken";
                    sina = new Client(oauth);
                }
                else
                {
                    statTxt.Text = "授权失败，未获取accesstoken";
                }
            }
            else
            {
                oauth = new OAuth(appKey, appSecret, accessToken, "");//最后一个参数是refreshtoken这个是面向高级用户对的
                TokenResult tokenResult = oauth.VerifierAccessToken();
                if (tokenResult == TokenResult.Success)
                {
                    statTxt.Text = "验证本地accesstoken有效";
                    sina = new Client(oauth);
                }
                else
                {                   
                    Properties.Settings.Default.AcessToken = string.Empty;
                    Properties.Settings.Default.Save();
                    statTxt.Text = "验证本地accesstoken无效，尝试重新授权";
                    oauth = Authorize();
                    if (!string.IsNullOrEmpty(oauth.AccessToken))
                    {
                        Properties.Settings.Default.AcessToken = oauth.AccessToken;
                        Properties.Settings.Default.Save();
                        statTxt.Text = "授权成功，重新保存accesstoken";
                        sina = new Client(oauth);
                    }
                    else
                    {
                        statTxt.Text = "授权失败，未获取accesstoken";
                    }
                }
            }
        }

        static OAuth Authorize()
        {
            OAuth oauth = null;
            oauth = new OAuth(Properties.Settings.Default.AppKey, Properties.Settings.Default.AppSecret, Properties.Settings.Default.CallBackUrl);
            while (!ClientLogin(oauth))
            {
                //尝试登陆直到登上为止
            }
            return oauth;
        }

        private static bool ClientLogin(OAuth o)
        {
            string username="onepiecelx@sina.com";
            string password="marksman";

            return o.ClientLogin(username, password);
        }

        private void weiboBtn_Click(object sender, EventArgs e)
        {
            if (sina != null)
            {
                try
                {
                    sina.API.Statuses.Update("当前寝室里的温度："+temperature+"摄氏度", 0, 0, null);
                    statTxt.Text = "成功发布一条新微薄"+temperature;
                    WeiboUpTimer.Enabled = true;
                    WeiboUpTimer.Start();
                }
                catch (WeiboException ex)
                {
                    statTxt.Text = "发布微薄失败，原因" + ex.Message;
                }
            }

        }

        private void readBtn_Click(object sender, EventArgs e)
        {
            serialReadFlag = !serialReadFlag;
            if (serialReadFlag)
            {
                arduinoSerial.Open();
                readBtn.Text = "停止获取串口数据";
            }
            else
            {
                arduinoSerial.Close();
                readBtn.Text = "开始获取串口数据";
            }
        }

        private void arduinoSerial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            
            SerialPort serial = (SerialPort)sender;
            temperature = serial.ReadLine();
            temperature = temperature.Replace("\n", "");
            
        }

        private void WeiboUpTimer_Tick(object sender, EventArgs e)
        {
            if (sina != null)
            {
                try
                {
                    sina.API.Statuses.Update("当前寝室里的温度：" + temperature + "摄氏度", 0, 0, null);
                    statTxt.Text = "成功发布一条新微薄"+temperature;
                    
                }
                catch (WeiboException ex)
                {
                    statTxt.Text = "发布微薄失败，原因" + ex.Message;
                }
            }
        }
    }
}
