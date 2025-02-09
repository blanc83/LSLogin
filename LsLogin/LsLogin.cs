using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace LsLogin
{

    public partial class LsLogin : Form
    {
        private LoginResult _result;

        public LsLogin()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string UserID = txtUserID.Text;
            string userPWD = txtUserPWD.Text;

            _result = GetLoginKeyValofe(UserID, userPWD);

            if (_result.szResultKey == "error code1")
            {
                MessageBox.Show("로그인 중 오류가 발생했습니다.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLoginKey.Text = "";
            }
            else if (_result.szResultKey == "error code2")
            {
                MessageBox.Show("실행 URL을 가져오는 데 실패했습니다.", "실행 URL 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLoginKey.Text = "";
            }
            else
            {
                txtLoginKey.Text = _result.szLoginKey;

            }
        }

        private LoginResult GetLoginKeyValofe(string szUserID, string szUserPWD)
        {
            LoginResult kResult = new LoginResult(szUserID, szUserPWD);
            ChromeOptions options = new ChromeOptions();

            // 드라이버 경로 설정
            string chromeDriverPath = @"C:\Users\05053\Downloads\chromedriver-win64";

            // ChromeDriverService를 숨기기 위한 설정 추가
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(chromeDriverPath);
            service.HideCommandPromptWindow = true;  // 콘솔 창 숨김

            using (IWebDriver driver = new ChromeDriver(service, options))
            {
                try
                {
                    driver.Navigate().GoToUrl("https://member.valofe.com/login/login.asp?ret=http%3A%2F%2Flostsaga-ko.valofe.com%2Fmain%2Fmain.asp");
                    driver.FindElement(By.Id("uid")).SendKeys(szUserID);
                    driver.FindElement(By.Id("passwd")).SendKeys(szUserPWD);
                    driver.FindElement(By.ClassName("btnLogin")).Click();

                    // 조금 더 긴 대기 시간 추가
                    Thread.Sleep(2000);  // 2초 대기

                    driver.Navigate().GoToUrl("https://lostsaga-ko.valofe.com/login/login_main_info.asp");
                    try
                    {
                        kResult.szName = driver.FindElement(By.XPath("/html/body/fieldset/div/div[1]/strong")).Text;
                        kResult.szGrade = driver.FindElement(By.XPath("/html/body/fieldset/div/div[2]/span[2]")).Text;
                    }
                    catch (Exception) { }

                    driver.Navigate().GoToUrl("http://lostsaga-ko.valofe.com/play/playUrl.asp");
                    try
                    {
                        var Element = driver.FindElement(By.Id("playgame"));
                        kResult.szResultKey = Element.GetAttribute("href");
                        kResult.szLoginKey = ParseKey(kResult.szResultKey);
                    }
                    catch (Exception)
                    {
                        kResult.szResultKey = "error code2";
                    }
                }
                catch (Exception)
                {
                    kResult.szResultKey = "error code1";
                }
            }
            return kResult;
        }

        private string ParseKey(string szkey)
        {
            szkey = szkey.Replace("lostsaga://", "");
            string[] vkey = szkey.Split(',');
            string szIDKey = vkey[0];
            string szIPKey = vkey[1];
            string szServerID = vkey[2];
            return $"EDEW3940FVDP4950,10,20,30,1,autoupgrade_info.ini,1000,0,1,0,?{szIDKey}?0?{szIPKey}?{szServerID}?2010,7,15,1?10201?";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_result == null || string.IsNullOrEmpty(_result.szName) || string.IsNullOrEmpty(_result.szGrade))
            {
                MessageBox.Show("로그인 상태에서 가능합니다.", "로그인 필요", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string szName = _result.szName;
            string szGrade = _result.szGrade;

            string LSFName = $"{szName}_{szGrade}.bat";
            string FPath = Path.Combine(@"C:\Program Files\Lostsaga", LSFName);

            // 로그인 키가 비어 있으면 오류 처리
            string LoginBox = txtLoginKey.Text;
            if (string.IsNullOrEmpty(LoginBox))
            {
                MessageBox.Show("로그인 키가 없습니다. 먼저 로그인 시도해주세요.", "로그인 필요", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // .bat 파일 내용 생성
                string batContent = $"start lostsaga.exe {LoginBox}";
                File.WriteAllText(FPath, batContent);

                MessageBox.Show($"배치 파일이 생성되었습니다: {FPath}", "배치 파일 생성 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"배치 파일 생성 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            if (_result == null || string.IsNullOrEmpty(_result.szName) || string.IsNullOrEmpty(_result.szGrade))
            {
                MessageBox.Show("로그인 상태에서 가능합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string LKey = txtLoginKey.Text;

            if (string.IsNullOrEmpty(LKey))
            {
                MessageBox.Show("Null Parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string LSDir = @"C:\Program Files\Lostsaga";
                string LSExe = Path.Combine(LSDir, "lostsaga.exe");
                //string StartCom = $"/c cd \"{LSDir}\" && start {LSExe} {LKey}";


                ProcessStartInfo _Start = new ProcessStartInfo()
                {
                    FileName = LSExe,
                    Arguments = LKey,
                    WorkingDirectory = LSDir,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                };
                Process process = Process.Start(_Start);

                MessageBox.Show("Start Lostsaga", "Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public class LoginResult
        {

            public string szID;
            public string szPWD;
            public string szName;
            public string szGrade;
            public string szResultKey;
            public string szLoginKey;

            public LoginResult(string id, string pwd)
            {
                szID = id;
                szPWD = pwd;
            }
        }
    }
}
