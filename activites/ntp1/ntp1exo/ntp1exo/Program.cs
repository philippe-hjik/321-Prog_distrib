using System;
using System.Net;
using System.Net.Sockets;

hstring ntpServer = "0.ch.pool.ntp.org";
byte[] ntpData = new byte[48];
ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

IPEndPoint ntpEndpoint = new IPEndPoint(Dns.GetHostAddresses(ntpServer)[0], 123);

UdpClient ntpClient = new UdpClient();
ntpClient.Connect(ntpEndpoint);


ntpClient.Send(ntpData, ntpData.Length);

ntpData = ntpClient.Receive(ref ntpEndpoint);

DateTime ntpTime = NtpPacket.ToDateTime(ntpData);

Console.WriteLine("Heure actuelle : " + ntpTime.ToString());

ntpClient.Close();

TimeSpan timeSpan = DateTime.Now - ntpTime;

Console.WriteLine("Différence : " + timeSpan.ToString());

DateTime correctTime = ntpTime + timeSpan;
Console.WriteLine("Correction : " + correctTime.ToString());

DateTime correct = correctTime.ToUniversalTime();                                             
public class NtpPacket
{
    public static DateTime ToDateTime(byte[] ntpData)
    {
        // Extract integer and fractional parts from the NTP data bytes
        ulong intPart = ((ulong)ntpData[40] << 24) | ((ulong)ntpData[41] << 16) | ((ulong)ntpData[42] << 8) | ntpData[43];
        ulong fractPart = ((ulong)ntpData[44] << 24) | ((ulong)ntpData[45] << 16) | ((ulong)ntpData[46] << 8) | ntpData[47];

        // Calculate the milliseconds since January 1, 1900
        var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

        // Convert NTP time to DateTime (NTP time starts from 1900-01-01)
        DateTime networkDateTime = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        networkDateTime = networkDateTime.AddMilliseconds((long)milliseconds);

        return networkDateTime;
    }
}



