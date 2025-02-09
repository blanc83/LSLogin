using System;
using System.Windows.Forms;

namespace LsLogin
{
    static class Program
    {
        // 애플리케이션의 진입점
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // 첫 번째 폼을 실행
            Application.Run(new LsLogin());  // 여기서 Form1이 애플리케이션의 첫 폼
        }
    }
}
