# ServiceDns
Create And Remove Dns In C#

با استفاده از این نرم افزار نام دامنه را در تکست باکس وارد کنید و دی ان اس را ایجاد یا حذف کنید
اما استفاده ی دیگری که می توان از این نرم افزار کرد در ایجاد و یا حذف اتوماتیک می باشد به این صورت که کد را بصورت زیر در لود صفحه قرار دهید
<br/>
.................................................................
<br/>
<p dir="ltr">
Using this software, enter the domain name in the text box and create or delete DNS
But another use that can be made of this software is to create or delete automatically by putting the code below in the page load.
</p>
<br/>






    string[] args = Environment.GetCommandLineArgs();
    if (args.Length > 1)
    {
    
        InitialSessionState iss = InitialSessionState.CreateDefault2();
        var shell = PowerShell.Create(iss);
        shell.Commands.AddScript(@"Add-DnsServerPrimaryZone -Name " + args[1] + " -ZoneFile " + args[1] + ".dns");
        shell.Commands.AddScript("Add-DnsServerResourceRecordA -Name \"@\" -ZoneName \"" + args[1] + "\" -AllowUpdateAny -IPv4Address \"37.156.145.183\" -TimeToLive 01:00:00");
        shell.Commands.AddScript("Add-DnsServerResourceRecordA -Name \"www\" -ZoneName \"" + args[1] + "\" -AllowUpdateAny -IPv4Address \"37.156.145.183\" -TimeToLive 01:00:00");
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
                textBox1.Text = "Add-DnsServerResourceRecordA -Name \"@\" -ZoneName \"" + args[1] + "\" -AllowUpdateAny -IPv4Address \"172.18.99.23\" -TimeToLive 01:00:00";
            }
        }
        catch (Exception ex) { }
    }

