using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCFF
{
    public partial class jobcreation : Form
    {
        int owmyass = 0;
        public jobcreation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            btn_CLR.BackColor = cd.Color;
        }

        private void jobcreation_Load(object sender, EventArgs e)
        {
            activate_volet(1);
            activate_volet(2);
            checkBox2.Enabled = false;
            activate_volet(3);
            activate_volet(4);
        }

        void activate_volet(int vol)
        {
            if (vol == 1)
            {
                gb_PERMISSION.Enabled = not(gb_PERMISSION.Enabled);
            }
            else if(vol == 2)
            {
                gb_TYPE.Enabled = not(gb_TYPE.Enabled);
            }else if (vol == 3)
            {
                gb_SPAWN.Enabled = not(gb_SPAWN.Enabled);
            }else if (vol == 4)
            {
                gb_OTHER.Enabled = not(gb_OTHER.Enabled);
            }
        }

        bool not(bool input)
        {
            if (input == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            activate_volet(2);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            activate_volet(1);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            activate_volet(3);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            activate_volet(4);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            /*MessageBox.Show(@"It just works, it just works
Little lies, stunning shows
People buy, money flows, it just works
It just works, it just works
Overpriced open worlds
Earnings rise, take my word
It just works
It just works
It just works
It just works");*/
            if (textBox1.Text.Length > 0)
            {
                Clipboard.SetText(textBox1.Text);
                owmyass = 0;
            }
            else
            {
                owmyass += 1;
                if(owmyass == 1)
                {
                    MessageBox.Show("SMG4");
                }
                
                if (owmyass == 39)
                {
                    SoundPlayer snd = new SoundPlayer(Properties.Resources.extreme_edition);
                    snd.Play();
                    MessageBox.Show(@"It just works, it just works
Little lies, stunning shows
People buy, money flows, it just works
It just works, it just works
Overpriced open worlds
Earnings rise, take my word
It just works
It just works
It just works
It just works");
Clipboard.SetText(@"It just works, it just works
Little lies, stunning shows
People buy, money flows, it just works
It just works, it just works
Overpriced open worlds
Earnings rise, take my word
It just works
It just works
It just works
It just works");
                }
                
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string tl = transform_lua();
            if (not(tl == "none"))
            {
                textBox1.Text = transform_lua();
            }
        }

        string transform_lua()
        {
            string basetxt = "";
            bool g = true;

            /*
             * BASE
             */
            // TEAM_ID
            if (not(tb_TEAMID.Text == "") && g) {
                basetxt += tb_TEAMID.Text + " = DarkRP.CreateJob\"";
            }
            else
            {
                MessageBox.Show("Une erreur est détecté !\n\nTEAM_ID INCORRECT");
                return "none";
            }
            // NAME
            if (not(tb_NAME.Text == "") && g)
            {
                basetxt += tb_NAME.Text + "\", {";
            }
            else
            {
                MessageBox.Show("Une erreur est détecté !\n\nNAME INCORRECT");
                return "none";
            }
            // CATEGORY
            if (not(tb_CATEGORY.Text == "") && g)
            {
                basetxt += "\n\tcategory = \"" + tb_CATEGORY.Text + "\",";
            }
            // MODEL
            if (not(tb_MODEL.Text == "") && g)
            {
                if (tb_MODEL.Text.EndsWith(";")) { tb_MODEL.Text = tb_MODEL.Text.Substring(0, tb_MODEL.Text.Length - 1); }
                basetxt += "\n\tmodel = {\"" + tb_MODEL.Text.Replace(";","\",\"") + "\"},";
            }
            else
            {
                MessageBox.Show("Une erreur est détecté !\n\nMODEL INCORRECT");
                return "none";
            }
            /*
             * JOB
             */
            // COLOR
            basetxt += "\n\tcolor = (" + btn_CLR.BackColor.R + "," + btn_CLR.BackColor.G + "," + btn_CLR.BackColor.B + "),";
            // DESCRIPTIONS
            if (not(tb_DESCRIPTION.Text == "") && g)
            {
                basetxt += "\n\tdescription = [[" + tb_DESCRIPTION.Text + "]],";
            }
            else
            {
                MessageBox.Show("Une erreur est détecté !\n\nDESCRIPTIONS INCORRECT");
                return "none";
            }
            // COMMAND
            if (not(tb_COMMAND.Text == "") && g)
            {
                basetxt += "\n\tcommand = \"" + tb_COMMAND.Text + "\",";
            }
            else
            {
                MessageBox.Show("Une erreur est détecté !\n\nCOMMAND INCORRECT");
                return "none";
            }
            // WEAPONS
            if (not(tb_WEAPON.Text == "") && g)
            {
                if (tb_WEAPON.Text.EndsWith(";")) { tb_WEAPON.Text = tb_WEAPON.Text.Substring(0, tb_WEAPON.Text.Length - 1); }
                basetxt += "\n\tweapons = {\"" + tb_WEAPON.Text.Replace(";", "\",\"") + "\"},";
            }
            else
            {
                basetxt += "\n\tweapons = {},";
            }
            // Change
            if (not(tb_CHANGE.Text == "") && g)
            {
                basetxt += "\n\tNeedToChangeFrom = \"" + tb_CHANGE.Text + "\",";
            }

            /*
            * ECONOMY
            */
            // SALARY
            basetxt += "\n\tsalary = \"" + nud_SALARY.Value + "\",";
            // Max
            basetxt += "\n\tsalary = \"" + nud_MAX.Value + "\",";

            /*
            * Permission
            */
            if (gb_PERMISSION.Enabled == true)
            {
                // ACCESS
                if (not(cbb_ACCESS.Text == "") && g)
                {
                    basetxt += "admin = " + cbb_ACCESS.Text.Substring(1,1) + ",";
                }
                else
                {
                    MessageBox.Show("Une erreur est détecté !\n\nACCESS INCORRECT");
                    return "none";
                }
                // VOTE
                if (not(cbb_VOTE.Text == "") && g)
                {
                    if (cbb_VOTE.Text.Substring(1, 4) == "true")
                    {
                        basetxt += "vote = true,";
                    }
                    else
                    {
                        basetxt += "vote = false,";
                    }
                }
                else
                {
                    MessageBox.Show("Une erreur est détecté !\n\nVOTE INCORRECT");
                    return "none";
                }
                // LICENCE D'ARME
                if (not(cbb_LICENCE.Text == "") && g)
                {
                    if (cbb_LICENCE.Text.Substring(1, 4) == "true")
                    {
                        basetxt += "hasLicence = true,";
                    }
                    else
                    {
                        basetxt += "hasLicence = false,";
                    }
                }
                else
                {
                    MessageBox.Show("Une erreur est détecté !\n\nLICENCE INCORRECT");
                    return "none";
                }
                // DEMOTE
                if (not(cbb_DEMOTE.Text == "") && g)
                {
                    if (cbb_DEMOTE.Text.Substring(1, 4) == "true")
                    {
                        basetxt += "canDemote = true,";
                    }
                    else
                    {
                        basetxt += "canDemote = false,";
                    }
                }
                else
                {
                    MessageBox.Show("Une erreur est détecté !\n\nDEMOTE INCORRECT");
                    return "none";
                }
            }
            else
            {
                basetxt += "\n\tadmin = 0,";
                basetxt += "\n\tvote = false,";
                basetxt += "\n\thasLicense = false,";
                basetxt += "\n\tcanDemote = false,";
            }
            /*
             * SPAWN
             */
            if (gb_SPAWN.Enabled == true)
            {
                string t = "\n\tPlayerSpawn = function(ply)";
                // HEALTH
                t += "\n\t\tply:SetHealth(" + nud_HEALTH.Value + ")";
                t += "\n\t\tply:SetMaxHealth(" + nud_HEALTH.Value + ")";
                // Armor
                if (nud_ARMOR.Value > 0)
                {
                    t += "\n\t\tply:SetArmor(" + nud_HEALTH.Value + ")";
                    t += "\n\t\tply:SetMaxArmor(" + nud_HEALTH.Value + ")";
                }
                t += "\n\tend,";
                basetxt += t;
            }
            /*
             * OTHER
             */
            if (gb_OTHER.Enabled == true)
            {
                
                // DEMOTE-DEATH
                if (not(cbb_DEMOTEDEATH.Text == "") && g)
                {
                    if (cbb_DEMOTEDEATH.Text.Substring(1, 4) == "true")
                    {
                        string t = "";
                        t += "\n\tPlayerDeath = function(ply,weapon;killer)";
                        t += "\n\t\tply:TeamBan()";
                        t += "\n\t\tply:changeTEAM(GAMEMODE.DefaultTeam, true)";
                        if (not(tb_MESSAGEDEMOTE.Text == ""))
                        {
                            t += "\n\t\tDarkRP.notifyAll(0,4, \"" + tb_MESSAGEDEMOTE + "\"";
                        }
                        t += "\n\tend,";
                    }
                }
                else
                {
                    MessageBox.Show("Une erreur est détecté !\n\nDEMOTE-DEATH INCORRECT");
                    return "none";
                }

                
                
            }



            if (not(g))
            {
                basetxt = "none";
            }
            else
            {
                basetxt += "\n})";
            }

            return basetxt;
        }
    }
}
