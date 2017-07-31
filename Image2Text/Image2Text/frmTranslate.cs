// Copyright (c) 2017 Scott Bishel
// License: Code Project Open License
// http://www.codeproject.com/info/cpol10.aspx

using RavSoft.GoogleTranslator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tesseract;

namespace ImageToText
{
    public partial class frmTranslate : Form
    {
        #region Fields

        frmCapture _capture;

        TesseractEngine _engine;

        Translator _translator;

        String _language = "eng";
        String _tessDataPsth = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\tessdata";

        Dictionary<string, string> _languageMap = new Dictionary<string, string>();

        bool _isModified = true;

        // Print Screen
//        const int VK_SNAPSHOT = 0x2C;
        const int VK_F4 = 0x73;
        #endregion

        public frmTranslate()
        {
            InitializeComponent();
        }

        #region Init
        void initLanuagePack()
        {
            _languageMap = new Dictionary<string, string>();
            _languageMap.Add("Afrikaans", "afr");
            _languageMap.Add("Albanian", "sqi");
            _languageMap.Add("Arabic", "ara");
            //_languageMap.Add("Armenian", "hy");
            _languageMap.Add("Azerbaijani", "aze");
            //_languageMap.Add("Basque", "eu");
            _languageMap.Add("Belarusian", "bel");
            _languageMap.Add("Bengali", "ben");
            _languageMap.Add("Bulgarian", "bul");
            _languageMap.Add("Catalan", "cat");
            //_languageMap.Add("Chinese", "zh-CN");
            //_languageMap.Add("Croatian", "hr");
            //_languageMap.Add("Czech", "cs");
            _languageMap.Add("Danish", "dan");
            //_languageMap.Add("Dutch", "nl");
            _languageMap.Add("English", "eng");
            _languageMap.Add("Esperanto", "epo");
            _languageMap.Add("Estonian", "est");
            //_languageMap.Add("Filipino", "tl");
            _languageMap.Add("Finnish", "fin");
            _languageMap.Add("French", "fra");
            //_languageMap.Add("Galician", "gl");
            //_languageMap.Add("German", "de");
            //_languageMap.Add("Georgian", "ka");
            //_languageMap.Add("Greek", "el");
            _languageMap.Add("Haitian Creole", "hat");
            _languageMap.Add("Hebrew", "heb");
            _languageMap.Add("Hindi", "hin");
            _languageMap.Add("Hungarian", "hun");
            _languageMap.Add("Icelandic", "isl");
            _languageMap.Add("Indonesian", "ind");
            //_languageMap.Add("Irish", "ga");
            _languageMap.Add("Italian", "ita");
            _languageMap.Add("Japanese", "jpn");
            _languageMap.Add("Korean", "kor");
            _languageMap.Add("Lao", "lao");
            _languageMap.Add("Latin", "lat");
            _languageMap.Add("Latvian", "lav");
            _languageMap.Add("Lithuanian", "lit");
            _languageMap.Add("Macedonian", "mkd");
            _languageMap.Add("Malay", "mal");
            _languageMap.Add("Maltese", "mlt");
            _languageMap.Add("Norwegian", "nor");
            //_languageMap.Add("Persian", "fa");
            _languageMap.Add("Polish", "pol");
            _languageMap.Add("Portuguese", "por");
            _languageMap.Add("Romanian", "ron");
            _languageMap.Add("Russian", "rus");
            _languageMap.Add("Serbian", "srp");
            _languageMap.Add("Slovak", "slk");
            _languageMap.Add("Slovenian", "slv");
            _languageMap.Add("Spanish", "est");
            _languageMap.Add("Swahili", "swa");
            _languageMap.Add("Swedish", "swe");
            _languageMap.Add("Tamil", "tam");
            _languageMap.Add("Telugu", "tel");
            _languageMap.Add("Thai", "tha");
            _languageMap.Add("Turkish", "tur");
            _languageMap.Add("Ukrainian", "ukr");
            _languageMap.Add("Urdu", "urd");
            _languageMap.Add("Vietnamese", "vie");
            _languageMap.Add("Welsh", "cym");
            _languageMap.Add("Yiddish", "yid");
        }

        void initEngine()
        {
            if (!_isModified)
                return;
            _isModified = false;

            if (_engine != null)
                _engine.Dispose();
            _engine = null;
            _engine = new TesseractEngine(_tessDataPsth, _language, EngineMode.Default);

            #region Performance Tweaks TODO
            _engine.SetVariable("tessedit_write_images", true);

            //Dictionary
            _engine.SetVariable("load_system_dawg", false);
            _engine.SetVariable("load_freq_dawg", false);

            //Japanese/Chinese
            _engine.SetVariable("chop_enable", "T");
            _engine.SetVariable("use_new_state_cost ", "F");
            _engine.SetVariable("segment_segcost_rating ", "F");
            _engine.SetVariable("enable_new_segsearch ", 0);
            _engine.SetVariable("language_model_ngram_on ", 0);
            _engine.SetVariable("textord_force_make_prop_words", "F");
            _engine.SetVariable("edges_max_children_per_outline", 40);
            #endregion

        }
        #endregion

        #region Form Method

        private void frmTranslate_Load(object sender, EventArgs e)
        {

            // Register a print screen hotkey
            RegisterHotKey(this.Handle, 0, 0, VK_F4);

            initLanuagePack();

            foreach(string kay in _languageMap.Keys)
            {
                cboSource.Items.Add(kay);
                cboTargt.Items.Add(kay);
            }
            cboSource.Sorted = true;
            cboSource.SelectedItem = "Japanese";
            cboTargt.Sorted = true;
            cboTargt.SelectedItem = "English";

            _translator = new Translator();

            CheckClipboard();
        }

        private void frmTranslate_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, 0);
            if (_engine != null)
                _engine.Dispose();
            _engine = null;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            rchResult.Clear();
            lblTranslateTime.Text = "N/A";
            lblMean.Text = "N/A";

            initEngine();

            string text = "";
            Page page = null;
            if (chkScreen.Checked)
            {
                Bitmap img = GetClipboardImage();
                if (img == null)
                    return;

                page = _engine.Process(img);

                img.Dispose();
            }
            else if (ofdImageSelect.ShowDialog() == DialogResult.OK)
            {
                rchResult.Clear();
                var testImagePath = ofdImageSelect.FileName;

                Pix img = Pix.LoadFromFile(testImagePath);
                if (img == null)
                    return;

                page = _engine.Process(img);

                img.Dispose();
            }

            if (page == null)
                return;

            text = page.GetText();
            lblMean.Text = String.Format("{0:P}", page.GetMeanConfidence());

            if(chkTranslate.Checked)
                Translate(text);
            else
                rchResult.AppendText(text);

            page.Dispose();
        }

        private void cboSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Selects the language to be used for decoding images
            String currentItem = _languageMap[cboSource.SelectedItem.ToString()];
            if (currentItem != _language)
            {
                _language = currentItem;
                _isModified = true;
            }

        }

        private void chkTranslate_CheckedChanged(object sender, EventArgs e)
        {
            cboTargt.Enabled = chkTranslate.Checked;
        }

        #endregion

        #region Clipboard
        void CheckClipboard()
        {
            if (Clipboard.ContainsImage())
                lblClipboard.Text = "Full";
            else
                lblClipboard.Text = "Empty";
        }

        Bitmap GetClipboardImage()
        {
            Image img = Clipboard.GetImage();
            if (img == null)
                return null;

            Bitmap bm = new Bitmap(img);
            return bm;
        }
        #endregion

        #region Translate
        void SetTranslate()
        {
            _translator.SourceLanguage = cboSource.SelectedItem.ToString();
            _translator.TargetLanguage = cboTargt.SelectedItem.ToString();
        }

        void Translate(string text)
        {
            SetTranslate();

            _translator.SourceText = text;

            try
            {
                _translator.Translate();
                rchResult.AppendText(_translator.Translation);

                lblTranslateTime.Text = _translator.TranslationTime.ToString();
            }
            catch {
                rchResult.AppendText("Unable to translate text");
            }
        }
        #endregion

        #region Capture Screen

        #region API
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int WM_HOTKEY = 0x312;
        #endregion

        #region WndProc
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {

            if (m.Msg == WM_HOTKEY)
            {
                if (_capture == null)
                {
                    _capture = new frmCapture();
                    _capture.Show();
                }
                else
                {
                    if (_capture.regionDrawn)
                    {
                        Image img = clsScreenCapture.CaptureDeskTopRectangle(_capture.boundsRect);
                        Clipboard.SetImage(img);
                        _capture.Close();
                        _capture.Dispose();
                        _capture = null;

                        lblClipboard.Text = "Full";
                    }
                    else
                    {
                        _capture.Close();
                        _capture.Dispose();
                        _capture = null;
                    }
                }
            }
            base.WndProc(ref m);
        }

        #endregion
        #endregion
    }
}
