using System;
using System.Windows.Forms;

namespace Bonus_Program
{
    public class ScannerInputHandler
    {
        private readonly TextBox _textBox;
        private readonly Action _onScanComplete;
        private DateTime _firstKeyTime;
        private string _buffer;
        private bool _isReceiving;
        private const int MaxInputDurationMs = 150;
        private const int MinScanLength = 3;

        public ScannerInputHandler(TextBox textBox, Action onScanComplete)
        {
            _textBox = textBox;
            _onScanComplete = onScanComplete;
            _buffer = string.Empty;
            _isReceiving = false;

            _textBox.KeyPress += OnKeyPress;
            _textBox.KeyDown += OnKeyDown;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && _isReceiving)
            {
                var elapsed = (DateTime.Now - _firstKeyTime).TotalMilliseconds;
                if (elapsed <= MaxInputDurationMs && _buffer.Length >= MinScanLength)
                {
                    _textBox.Text = _buffer;
                    _onScanComplete?.Invoke();
                }

                _buffer = string.Empty;
                _isReceiving = false;
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (!_isReceiving)
            {
                _firstKeyTime = DateTime.Now;
                _buffer = string.Empty;
                _isReceiving = true;
            }
            else
            {
                var elapsed = (DateTime.Now - _firstKeyTime).TotalMilliseconds;
                if (elapsed > MaxInputDurationMs)
                {
                    _buffer = string.Empty;
                    _isReceiving = false;
                    e.Handled = true;
                    return;
                }
            }

            _buffer += e.KeyChar;
            e.Handled = true;
        }
    }
}
