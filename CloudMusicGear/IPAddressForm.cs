using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudMusicGear.Annotations;

namespace CloudMusicGear
{
    // ReSharper disable once InconsistentNaming
    public partial class IPAddressForm : Form
    {
        public IPAddressForm()
        {
            InitializeComponent();
        }

        private readonly BindingSource _bindingSource = new BindingSource();

        private void IPAddressForm_Load(object sender, EventArgs e)
        {
            var ipAddressList = new BindingList<IPAddressItem>
            {
                new IPAddressItem("103.4.200.196"),
                new IPAddressItem("103.4.200.226"),
                new IPAddressItem("115.231.158.44"),
                new IPAddressItem("115.231.171.46"),
                new IPAddressItem("122.226.182.76"),
                new IPAddressItem("122.226.182.77"),
                new IPAddressItem("122.226.213.107"),
                new IPAddressItem("123.58.180.105"),
                new IPAddressItem("123.58.180.106"),
                new IPAddressItem("180.153.126.29"),
                new IPAddressItem("180.97.180.71"),
                new IPAddressItem("183.131.161.29"),
                new IPAddressItem("183.131.161.44"),
                new IPAddressItem("183.131.82.15"),
                new IPAddressItem("222.186.160.173"),
                new IPAddressItem("222.186.160.183"),
                new IPAddressItem("49.79.232.58"),
                new IPAddressItem("58.220.2.78"),
                new IPAddressItem("58.220.2.95"),
                new IPAddressItem("61.153.56.132"),
                new IPAddressItem("61.160.243.142"),
                new IPAddressItem("61.160.243.143"),
                new IPAddressItem("61.160.243.144"),
                new IPAddressItem("61.160.243.145"),
                new IPAddressItem("61.160.243.176"),
                new IPAddressItem("61.160.243.177"),
                new IPAddressItem("61.160.243.182"),
                new IPAddressItem("61.160.243.183"),
                new IPAddressItem("61.160.243.184"),
                new IPAddressItem("61.160.243.185"),
                new IPAddressItem("111.161.66.70"),
                new IPAddressItem("111.47.243.70"),
                new IPAddressItem("111.47.243.71"),
                new IPAddressItem("112.25.57.4"),
                new IPAddressItem("112.90.222.30"),
                new IPAddressItem("113.207.34.208"),
                new IPAddressItem("117.177.240.83"),
                new IPAddressItem("117.177.240.84"),
                new IPAddressItem("117.177.240.85"),
                new IPAddressItem("117.177.240.86"),
                new IPAddressItem("117.177.240.87"),
                new IPAddressItem("120.192.200.52"),
                new IPAddressItem("120.192.200.53"),
                new IPAddressItem("120.192.200.54"),
                new IPAddressItem("120.192.249.76"),
                new IPAddressItem("123.138.188.131"),
                new IPAddressItem("123.150.52.162"),
                new IPAddressItem("123.150.53.8"),
                new IPAddressItem("123.159.202.138"),
                new IPAddressItem("124.239.198.199"),
                new IPAddressItem("124.239.198.200"),
                new IPAddressItem("124.67.23.15"),
                new IPAddressItem("163.177.135.198"),
                new IPAddressItem("163.177.135.199"),
                new IPAddressItem("163.177.135.206"),
                new IPAddressItem("163.177.135.207"),
                new IPAddressItem("163.177.169.204"),
                new IPAddressItem("163.177.169.205"),
                new IPAddressItem("163.177.169.221"),
                new IPAddressItem("183.95.153.10"),
                new IPAddressItem("210.76.57.7"),
                new IPAddressItem("218.24.18.8"),
                new IPAddressItem("218.29.229.200"),
                new IPAddressItem("221.181.207.175"),
                new IPAddressItem("221.194.130.200"),
                new IPAddressItem("221.194.130.202"),
                new IPAddressItem("221.194.130.203"),
                new IPAddressItem("60.6.196.135")
            };

            _bindingSource.DataSource = ipAddressList;
            ipAddressCheckedListBox.DataSource = _bindingSource;
            ipAddressCheckedListBox.DisplayMember = "Status";

            for (var i = 0; i < ipAddressCheckedListBox.Items.Count; ++i)
            {
                var isChecked = Config.IpAddressList.Contains(((IPAddressItem) ipAddressCheckedListBox.Items[i]).IPAddress);
                ipAddressCheckedListBox.SetItemChecked(i, isChecked);
            }

            Task.Factory.StartNew(() =>
            {
                Parallel.ForEach(ipAddressList, ipAddressItem =>
                {
                    var pingSender = new Ping();
                    var pingInfo = pingSender.Send(ipAddressItem.IPAddress, 1000);
                    if (pingInfo != null && pingInfo.Status == IPStatus.Success)
                    {
                        Invoke(new Action(() => ipAddressItem.Ping = $"{pingInfo.RoundtripTime}ms"));
                    }
                    else
                    {
                        Invoke(new Action(() => ipAddressItem.Ping = "Timeout"));
                    }
                });
            });
        }

        // ReSharper disable InconsistentNaming
        private sealed class IPAddressItem : INotifyPropertyChanged
        {
            public string IPAddress { get; }
            // ReSharper restore InconsistentNaming
            // ReSharper disable once MemberCanBePrivate.Local
            public string Status => string.IsNullOrEmpty(Ping) ? IPAddress : $"{IPAddress} (Ping: {Ping})";
            public event PropertyChangedEventHandler PropertyChanged;
            private string _ping;

            public string Ping
            {
                private get { return _ping; }
                set
                {
                    _ping = value;
                    NotifyPropertyChanged(nameof(Status));
                }
            }

            [NotifyPropertyChangedInvocator]
            private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public IPAddressItem(string ipAddress)
            {
                IPAddress = ipAddress;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Config.IpAddressList = new StringCollection();
            foreach (IPAddressItem checkedItem in ipAddressCheckedListBox.CheckedItems)
            {
                Config.IpAddressList.Add(checkedItem.IPAddress);
            }
            Close();
        }
    }
}
