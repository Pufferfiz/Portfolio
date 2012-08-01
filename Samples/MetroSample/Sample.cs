
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("WARNING, this will edit the config file on your computer and steam account, make a back up of the default file. Also You must do that when steam is not active on your computer, log off steam run this app, then log back in.", "WARNING", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string metroExe = "";
            metroExe = lbFilename.Text; 
            metroExe = metroExe.Substring(0, 23);
            metroExe = metroExe.Insert(23,"steamapps\\common\\metro 2033\\Metro2033.exe");
            if (File.Exists(metroExe) == true)
            {
                Process.Start(metroExe);
            }
            if (File.Exists(metroExe) == false)
            {
                MessageBox.Show("Could not find Metro2033.exe, Launch Metro manually", "Error", MessageBoxButtons.OK);
            }

        }

        

        private void btSaveChanges_Click(object sender, EventArgs e)
        {
            //Formating
            //Lowers textboxes that are case sensative
            tbCrossHair.Text =  tbCrossHair.Text.ToLower();
            tbFullscreen.Text = tbFullscreen.Text.ToLower();
            tbStats.Text = tbStats.Text.ToLower();
            tbVsync.Text = tbVsync.Text.ToLower();
            tbHud.Text = tbHud.Text.ToLower();


            //End Lowering textboxes
            //End Formating
            
            //defines
            
            string subTitles = tbSubTitles.Text;
            string aimAssist = tbAimAssist.Text;
            string fastWeponChange = tbFastWeapChange.Text;
            string quickHints = tbGameHints.Text;
            string crossHairs = tbCrossHair.Text;
            string hRez = tbHRez.Text;
            string fullScreen = tbFullscreen.Text;
            string vRez = tbVertRez.Text;
            string fOV = tbFov.Text;
            string tesslllation = tbTessllation.Text;
            string depthOFfield = tbDepthof.Text;
            string mouseSens = tbMouseSens.Text;
            string aimSens = tbAimSens.Text;
            string stats = tbStats.Text;
            string vsync = tbVsync.Text;
            string deBlur = tbDeBlur.Text;
            string bloomTh = tbBloom.Text;
            string mastVol = tbMastVolum.Text;
            string musicVol = tbMusicVolum.Text;
            string hudDis = tbHud.Text;


            bool failcheck = false;
            

            //End Defines



            



            //syntax check
            failcheck = SyntaxCheck(failcheck);

            if (failcheck == true)
            {
                MessageBox.Show("One or more items are out of bounds", "Error", MessageBoxButtons.OK);
                
            }

            if (failcheck == false)
            {
                StreamWriter sw = new StreamWriter(lbFilename.Text);

                //Parese Code back

                code.Remove(code[0]);
                code.Insert(0, ("_show_subtitles " + subTitles));
                code.Remove(code[14]);
                code.Insert(14, ("aim_assist " + aimAssist + "."));
                code.Remove(code[69]);
                code.Insert(69, ("fast_wpn_change " + fastWeponChange));
                code.Remove(code[74]);
                code.Insert(74, ("g_quick_hints " + quickHints));
                code.Remove(code[75]);
                code.Insert(75, ("g_show_crosshair " + crossHairs));
                code[122] = ("r_res_hor " + hRez);
                code[123] = ("r_res_vert " + vRez);
                code[110] = ("r_fullscreen " + fullScreen);
                code[108] = ("r_dx11_tess " + tesslllation);
                code[107] = ("r_dx11_dof " + depthOFfield);
                code[86] = ("mouse_aim_sens " + aimSens);
                code[87] = ("mouse_sens " + mouseSens);
                code[145] = ("stats " + stats);
                code[134] = ("r_vsync " + vsync);
                code[105] = ("r_deblur_dist " + deBlur + ".");
                code[99] = ("r_bloom_threshold " + bloomTh);
                code[138] = ("s_master_volume " + mastVol);
                code[139] = ("s_music_volume " + musicVol);
                code[117] = ("r_hud_weapon " + hudDis);

                //End Parse

                //Write

                code.ForEach(sw.WriteLine);
                //End Write

                //rewrite debug for user
                textBox1.Text = "";
                foreach (string line in code)
                {
                    textBox1.Text = (textBox1.Text + line + Environment.NewLine);
                }
                // End of Rewrite
                sw.Close();
                
            }
            
            
        }
        
