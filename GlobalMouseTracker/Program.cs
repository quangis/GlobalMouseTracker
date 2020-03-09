/* 
 * MIT LICENSE
 * 
 * Copyright 2020 Enkhbold Nyamsuren
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
 * and associated documentation files (the "Software"), to deal in the Software without restriction, 
 * including without limitation the rights to use, copy, modify, merge, publish, distribute, 
 * sublicense, and/or sell copies of the Software, and to permit persons to whom the Software 
 * is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE 
 * AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
 * DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GlobalMouseTracker
{
    static class Program
    {
        public static event EventHandler MouseAction = delegate { };

        const int WH_MOUSE_LL = 14;
        private static LowLevelMouseProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        public const int DEF_MOVE_FREQ = 25;
        public const int MIN_MOVE_FREQ = 0;
        private static int moveFreq = DEF_MOVE_FREQ;
        private static long lastTrackTime = 0;

        public const int DEF_SAVE_FREQ = 500;
        public const int MIN_SAVE_FREQ = 1;
        private static int saveFreq = DEF_SAVE_FREQ;
        private static List<string> capture = new List<string>();

        private static bool tracing = false;

        private static Form1 form;

        private static bool moveFlag = true;
        private static bool leftFlag = true;
        private static bool rightFlag = true;
        private static bool wheelFlag = true;

        public static bool MoveFlag {
            get { return moveFlag; }
            set { moveFlag = value; }
        }

        public static bool LeftFlag {
            get { return leftFlag; }
            set { leftFlag = value; }
        }

        public static bool RightFlag {
            get { return rightFlag; }
            set { rightFlag = value; }
        }

        public static bool WheelFlag {
            get { return wheelFlag; }
            set { wheelFlag = value; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new Form1();
            Application.Run(form);
        }

        public static bool StartTracing() {
            if (!tracing) {
                _hookID = SetHook(_proc);

                if (_hookID == null) {
                    MessageBox.Show("SetWindowsHookEx Failed");
                    return false;
                }

                tracing = true;

                return true;
            }

            return false;
        }

        public static bool EndTracing() {
            if (tracing) {
                UnhookWindowsHookEx(_hookID);

                tracing = false;

                form.writeToFile(capture);
                capture.Clear();

                return true;
            }

            return false;
        }

        public static bool IsTracing() {
            return tracing;
        }

        public static bool setMoveFreq(int moveFreq) {
            if (moveFreq >= MIN_MOVE_FREQ) {
                Program.moveFreq = moveFreq;
                return true;
            }
            return false;
        }

        public static bool setSaveFreq(int saveFreq) {
            if (saveFreq >= MIN_SAVE_FREQ) {
                Program.saveFreq = saveFreq;
                return true;
            }
            return false;
        }

        private static IntPtr SetHook(LowLevelMouseProc proc) {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule) {
                /*return SetWindowsHookEx(WH_MOUSE_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);*/

IntPtr hook = SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle("user32"), 0);
                if (hook == IntPtr.Zero) {
                    throw new System.ComponentModel.Win32Exception();
                }
                return hook;
            }
        }

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        /*
         * nCode - A code the hook procedure uses to determine how to process the message. 
         *          If nCode is less than zero, the hook procedure must pass the message 
         *          to the CallNextHookEx function without further processing and should 
         *          return the value returned by CallNextHookEx.
         * wParam - The identifier of the mouse message. This parameter can be one of the following 
         *          messages: WM_LBUTTONDOWN, WM_LBUTTONUP, WM_MOUSEMOVE, WM_MOUSEWHEEL, 
         *          WM_MOUSEHWHEEL, WM_RBUTTONDOWN, or WM_RBUTTONUP.
         * lParam - A pointer to an MSLLHOOKSTRUCT structure.
         */
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
            if (nCode >= 0) {
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));

                switch ((MouseMessages)wParam) {
                    case MouseMessages.WM_MOUSEMOVE:
                        if (MoveFlag) {
                            long timeTicks = DateTime.Now.Ticks;
                            long msElapsed = (timeTicks - lastTrackTime) / TimeSpan.TicksPerMillisecond;

                            if (msElapsed >= moveFreq) {
                                lastTrackTime = timeTicks;
                                /*Console.WriteLine(msElapsed);
                                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff")
                                    + " " + hookStruct.pt.x + " " + hookStruct.pt.y + " " + "MOUSE_MOVE");*/
                                capture.Add(DateTime.Now.ToString("HH:mm:ss:fff")
                                    + " " + hookStruct.pt.x + " " + hookStruct.pt.y + " " + "MOUSE_MOVE");
                            }
                        }
                        break;
                    case MouseMessages.WM_LBUTTONDOWN:
                        if (LeftFlag) {
                            /*Console.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff")
                                + " " + hookStruct.pt.x + " " + hookStruct.pt.y + " " + "MOUSE_LEFT_DOWN");*/
                            capture.Add(DateTime.Now.ToString("HH:mm:ss:fff")
                                + " " + hookStruct.pt.x + " " + hookStruct.pt.y + " " + "MOUSE_LEFT_DOWN");
                        }
                        break;
                    case MouseMessages.WM_LBUTTONUP:
                        if (LeftFlag) {
                            /*Console.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff")
                                + " " + hookStruct.pt.x + " " + hookStruct.pt.y + " " + "MOUSE_LEFT_UP");*/
                            capture.Add(DateTime.Now.ToString("HH:mm:ss:fff")
                                + " " + hookStruct.pt.x + " " + hookStruct.pt.y + " " + "MOUSE_LEFT_UP");
                        }
                        break;
                    case MouseMessages.WM_RBUTTONDOWN:
                        if (RightFlag) {
                            /*Console.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff")
                                + " " + hookStruct.pt.x + " " + hookStruct.pt.y + " " + "MOUSE_RIGHT_DOWN");*/
                            capture.Add(DateTime.Now.ToString("HH:mm:ss:fff")
                                + " " + hookStruct.pt.x + " " + hookStruct.pt.y + " " + "MOUSE_RIGHT_DOWN");
                        }
                        break;
                    case MouseMessages.WM_RBUTTONUP:
                        if (RightFlag) {
                            /*Console.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff")
                                + " " + hookStruct.pt.x + " " + hookStruct.pt.y + " " + "MOUSE_RIGHT_UP");*/
                            capture.Add(DateTime.Now.ToString("HH:mm:ss:fff")
                                + " " + hookStruct.pt.x + " " + hookStruct.pt.y + " " + "MOUSE_RIGHT_UP");
                        }
                        break;
                    case MouseMessages.WM_MOUSEWHEEL:
                        if (WheelFlag) {
                            /*Console.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff")
                                + " " + hookStruct.pt.x + " " + hookStruct.pt.y + " " + "MOUSE_WHEEL");*/
                            capture.Add(DateTime.Now.ToString("HH:mm:ss:fff")
                                + " " + hookStruct.pt.x + " " + hookStruct.pt.y + " " + "MOUSE_WHEEL");
                        }
                        break;
                    default: break;
                }

                if (capture.Count >= saveFreq) {
                    form.writeToFile(capture);
                    capture.Clear();
                }

                MouseAction(null, new EventArgs());
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private enum MouseMessages {
            WM_MOUSEMOVE = 0x0200,
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT {
            public POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
