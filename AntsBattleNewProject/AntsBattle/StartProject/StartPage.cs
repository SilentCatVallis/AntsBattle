using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartProject
{
    public partial class StartPage : Form
    {
        private Data Data;
        private ComboBox FirstPlayerChoosen;
        private ComboBox SecondPlayerChoosen;
        private ComboBox MapChoosen;
        private TextBox LifeLength;
        private TextBox MouthLength;
        private TextBox FrogSleepTime;
        private Label Message;
        private bool IsReady;
        private string Args;

        public StartPage(Data data)
        {
            Data = data;
            new Button { Location = new Point(150, 200), Text = @"Start!", Width = 125, Height = 50 }.Click += ClickStart;
            new Button { Location = new Point(250, 5), Text = @"Set statements", Width = 155, Height = 115 }.Click += SetStatements;

            Width = 450;
            Height = 330;
            MinimumSize = new Size(Width, Height);
            MaximumSize = new Size(Width, Height);

            FirstPlayerChoosen = new ComboBox {Text = @"ChooseFirstPlayerName", Location = new Point(5, 5), Width = 200};
            SecondPlayerChoosen = new ComboBox { Text = @"ChooseSecondPlayerName", Location = new Point(5, 35), Width = 200 };
            foreach (var player in Data.Players)
            {
                FirstPlayerChoosen.Items.Add(player);
                SecondPlayerChoosen.Items.Add(player);
            }
            

            MapChoosen = new ComboBox { Text = @"ChooseMap", Location = new Point(5, 95), Width = 200 };
            foreach (var map in Data.Maps)
            {
                MapChoosen.Items.Add(map);
            }

            LifeLength = new TextBox {Text = "", Location = new Point(5, 130), Width = 120};
            MouthLength = new TextBox { Text = "", Location = new Point(145, 130), Width = 120 };
            FrogSleepTime = new TextBox { Text = "", Location = new Point(285, 130), Width = 120 };

            var lifeTimeLable = new Label {Text = @"set lifetime", Location = new Point(5, 150), Width = 120 };
            var mouthLengthLable = new Label { Text = @"set mouth length", Location = new Point(145, 150), Width = 120 };
            var frogSleepLable = new Label { Text = @"set sleep time", Location = new Point(285, 150), Width = 120 };
            Message = new Label {Location = new Point(150, 255), Width = 170};

            Controls.Add(FirstPlayerChoosen);
            Controls.Add(SecondPlayerChoosen);
            Controls.Add(MapChoosen);
            Controls.Add(LifeLength);
            Controls.Add(MouthLength);
            Controls.Add(FrogSleepTime);
            Controls.Add(lifeTimeLable);
            Controls.Add(mouthLengthLable);
            Controls.Add(frogSleepLable);
            Controls.Add(new Button { Location = new Point(150, 200), Text = @"Start!", Width = 125, Height = 50 });
            Controls.Add(new Button { Location = new Point(250, 5), Text = @"Set statements", Width = 155, Height = 115 });
            Controls.Add(Message);
        }

        private void SetStatements(object sender, EventArgs e)
        {
            //Message.Text = (string) FirstPlayerChoosen.SelectedItem;
            int lifeLength;
            int mouthLength;
            int sleepTime;
            if (FirstPlayerChoosen.SelectedItem == null ||
                SecondPlayerChoosen.SelectedItem == null ||
                MapChoosen.SelectedItem == null ||
                !int.TryParse(LifeLength.Text, out lifeLength) ||
                !int.TryParse(MouthLength.Text, out mouthLength) ||
                !int.TryParse(FrogSleepTime.Text, out sleepTime))
            {
                Message.Text = @"Not all field are correct";
                IsReady = false;
            }
            else
            {
                Message.Text = @"   Ready to start!";
                Args = LifeLength.Text + ' ' +
                    MouthLength.Text + ' ' +
                    FrogSleepTime.Text + ' ' +
                    (string) FirstPlayerChoosen.SelectedItem + ' ' +
                    (string) SecondPlayerChoosen.SelectedItem + ' ' +
                    (string) MapChoosen.SelectedItem;
                IsReady = true;
            }

        }

        public override sealed Size MaximumSize
        {
            get { return base.MaximumSize; }
            set { base.MaximumSize = value; }
        }

        public override sealed Size MinimumSize
        {
            get { return base.MinimumSize; }
            set { base.MinimumSize = value; }
        }

        private void ClickStart(object sender, EventArgs e)
        {
            if (IsReady)
            {
                Process.Start(@"AntsBattle.exe - ÿנכûך", Args);
                Message.Text = "";
            }
            else
            {
                Message.Text = @"Statements not filled";
            }
        }

        //public object ClickStart { get; set; }
    }
}
