using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceDns
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length > 1)
            {
                InitialSessionState iss = InitialSessionState.CreateDefault2();

              
                var shell = PowerShell.Create(iss);



                shell.Commands.AddScript(@"Add-DnsServerPrimaryZone -Name " + textBox1.Text.Trim() + " -ZoneFile " + textBox1.Text.Trim() + ".dns");
                shell.Commands.AddScript("Add-DnsServerResourceRecordA -Name \"@\" -ZoneName \"" + textBox1.Text.Trim() + "\" -AllowUpdateAny -IPv4Address \"37.156.145.173\" -TimeToLive 01:00:00");
                shell.Commands.AddScript("Add-DnsServerResourceRecordA -Name \"www\" -ZoneName \"" + textBox1.Text.Trim() + "\" -AllowUpdateAny -IPv4Address \"37.156.145.173\" -TimeToLive 01:00:00");
                
                try
                {
                    var results = shell.Invoke();

                  
                    if (results.Count > 0)
                    {
                      
                        var builder = new System.Text.StringBuilder();

                        foreach (var psObject in results)
                        {
                          
                            builder.Append(psObject.BaseObject.ToString() + "\r\n");
                        }
                    }
                }
                catch (Exception ex) { }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            //textBox1.Text = str;
            if (textBox1.Text.Length > 1)
            {
                InitialSessionState iss = InitialSessionState.CreateDefault2();

                var shell = PowerShell.Create(iss);

                shell.Commands.AddScript("Remove-DnsServerZone \"" + textBox1.Text.Trim() + "\" -PassThru -Force");
                try
                {
                    var results = shell.Invoke();

                    if (results.Count > 0)
                    {
                        var builder = new System.Text.StringBuilder();

                        foreach (var psObject in results)
                        {
                            builder.Append(psObject.BaseObject.ToString() + "\r\n");
                        }
                    }
                }
                catch (Exception ex) { }
            }

        }
    }
}
