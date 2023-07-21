using System;
using System.Net.Sockets;
using UnityEngine;
using System.Text;
public class SacnController : MonoBehaviour
{}/*
    private UdpClient udpClient;
    private byte[] sacnPacket = new byte[SacnConstants.SacnBufferMax];
    
    private UDP udp;
    private bool unicastMode;
    private ushort universe;
    private ushort priority;
    private IPAddress ip;
    private bool priorityDD;
    private byte[] cid = new byte[16];
    private char[] name = new char[Constants.SourceNameSize - 1];
    private byte[] sacnPacketDD;

    private void Start(){
        udpClient = new UdpClient();
        Source();
    }

    private void OnDestroy(){
        udpClient.Close();
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            //SendSacn();
        }
    }

    private void SendSacn(string message){
        try{
            byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            udpClient.Send(data, SacnConstants.SacnBufferMax, targetIPAddress, SacnConstants.AcnSdtMulticastPort);
        } catch (System.Exception e){
            Debug.LogError(e);
        }
    }

    public void Source(UDP udp, IPAddress ip, ushort universe, ushort priority, byte[] cid, string name, bool priorityDD)
    {
        this.unicastMode = true;
        this.udp = udp;
        this.universe = universe;
        this.priority = priority;
        this.ip = ip;
        this.priorityDD = priorityDD;
        Array.Copy(cid, this.cid, SacnConstants.CidSize);
        name.CopyTo(0, this.name, 0, Math.Min(name.Length, SacnConstants.SourceNameSize - 1));

        sacnPacket = new byte[SacnConstants.SacnBufferMax];
        InitPacket(sacnPacket);

        if (priorityDD)
        {
            sacnPacketDD = new byte[SacnConstants.SacnBufferMax];
            InitPacket(sacnPacketDD);
            sacnPacketDD[SacnConstants.StartcodeAddr] = SacnConstants.StartcodeDd;
            Array.Fill(sacnPacketDD, SacnConstants.PriorityStandard, SacnConstants.DmxValuesAddr, SacnConstants.DmxSlotsMax);
        }
    }

    private void InitPacket(byte[] packet)
    {
        Array.Clear(packet, 0, SacnConstants.SacnBufferMax);
        
        // root layer
        packet[SacnConstants.PreambleAddr] = SacnConstants.Preamble[0];
        packet[SacnConstants.PreambleAddr + 1] = SacnConstants.Preamble[1];
        packet[SacnConstants.PostambleAddr] = SacnConstants.Postamble[0];
        packet[SacnConstants.PostambleAddr + 1] = SacnConstants.Postamble[1];
        Array.Copy(SacnConstants.AcnIdentifier, 0, packet, SacnConstants.AcnIdentifierAddr, SacnConstants.AcnIdentifierSize);
        Array.Copy(SacnConstants.RootFlagsAndLength, 0, packet, SacnConstants.RootFlagsAndLengthAddr, SacnConstants.RootFlagsAndLengthSize);
        Array.Copy(SacnConstants.VectorRootE131Data, 0, packet, SacnConstants.VectorRootE131DataAddr, SacnConstants.VectorRootE131DataSize);
        Array.Copy(cid, 0, packet, SacnConstants.CidAddr, SacnConstants.CidSize);

        // framing layer
        Array.Copy(SacnConstants.FramingFlagsAndLength, 0, packet, SacnConstants.FramingFlagsAndLengthAddr, SacnConstants.FramingFlagsAndLengthSize);
        Array.Copy(SacnConstants.VectorE131DataPacket, 0, packet, SacnConstants.VectorE131DataPacketAddr, SacnConstants.VectorE131DataPacketSize);
        Encoding.ASCII.GetBytes(name, 0, Math.Min(name.Length, SacnConstants.SourceNameSize - 1), packet, SacnConstants.SourceNameAddr);
        packet[SacnConstants.PriorityAddr] = (byte)priority;
        packet[SacnConstants.UniverseAddr] = (byte)(universe >> 8);
        packet[SacnConstants.UniverseAddr + 1] = (byte)universe;

        // dmp layer
        Array.Copy(SacnConstants.DmpFlagsAndLength, 0, packet, SacnConstants.DmpFlagsAndLengthAddr, SacnConstants.DmpFlagsAndLengthSize);
        packet[SacnConstants.VectorDmpSetPropertyAddr] = SacnConstants.VectorDmpSetProperty;
        packet[SacnConstants.DmpAddressAndDataAddr] = SacnConstants.DmpAddressAndData;
        Array.Copy(SacnConstants.AddressInc, 0, packet, SacnConstants.AddressIncAddr, SacnConstants.AddressIncSize);
        Array.Copy(SacnConstants.PropertyValueCount, 0, packet, SacnConstants.PropertyValueCountAddr, SacnConstants.PropertyValueCountSize);
    }
}
public static class SacnConstants
{
    // sACN Constants
    // Buffer
    public const int SacnBufferMin = 126;
    public const int SacnBufferMax = 638;
    public const int DmxSlotsMax = 512;

    // Ethernet
    public const int AcnSdtMulticastPort = 5568;

    // DMX Universes
    public const int UniverseMax = 63999;

    // Startcodes
    public const byte StartcodeDmx = 0x00;
    public const byte StartcodeDd = 0xDD;
    public const byte StartcodeRdm = 0xCC;
    public const byte StartcodeAscii = 0x17;
    public const byte StartcodeTest = 0x55;
    public const byte StartcodeUtf8 = 0x90;
    public const byte StartcodeSip = 0xCF;

    // Priorities
    public const int PriorityStandard = 100;
    public const int PriorityMax = 200;

    // Option Flags
    public const byte PreviewData = 0x80; // Bit 7
    public const byte StreamTerminated = 0x40; // Bit 6
    public const byte ForceSync = 0x10; // Bit 5

    // Timing Variables and others in ms
    public const int E131NetworkDataLossTimeout = 2500; // ms

    // timing constants for extensions
    public const int SacnPollingTime = 800; // 800 ms initialize 3 times in 1 s
    public const int SacnPollingTimeDd = 800; // 800 ms initialize and on change 3 times in 1 s

    // sACN const values and variables

    // Root Layer RLP
    public static int PreambleAddr = 0;
    public static int PreambleSize = 2;
    public static readonly byte[] Preamble = { 0x00, 0x10 };
    public static int PostambleAddr = 2;
    public static int PostambleSize = 2;
    public static readonly byte[] Postamble = { 0x00, 0x00 };
    public static int AcnIdentifierAddr = 4;
    public static int AcnIdentifierSize = 12;
    public static readonly byte[] AcnIdentifier = { 0x41, 0x53, 0x43, 0x2D, 0x45, 0x31, 0x2E, 0x31, 0x37, 0x00, 0x00, 0x00 }; // "ASC-E1.17\0\0\0"
    public static int RootFlagsAndLengthAddr = 16;
    public static int RootFlagsAndLengthSize = 2;
    public static readonly byte[] RootFlagsAndLength = { 0x72, 0x6E }; // SACN_BUFFER_MAX - ROOT_FLAGS_AND_LENGTH_ADDR + 0x7000
    public static int VectorRootE131DataAddr = 18;
    public static int VectorRootE131DataSize = 4;
    public static readonly byte[] VectorRootE131Data = { 0x00, 0x00, 0x00, 0x04 };
    public static int CidAddr = 22;
    public const int CidSize = 16;

    // Framing Layer
    public static int FramingFlagsAndLengthAddr = 38;
    public static int FramingFlagsAndLengthSize = 2;
    public static readonly byte[] FramingFlagsAndLength = { 0x72, 0x58 }; // SACN_BUFFER_MAX - FRAMING_FLAGS_AND_LENGTH_ADDR + 0x7000
    public static int VectorE131DataPacketAddr = 40;
    public static int VectorE131DataPacketSize = 4;
    public static readonly byte[] VectorE131DataPacket = { 0x00, 0x00, 0x00, 0x02 };
    public static int SourceNameAddr = 44;
    public const int SourceNameSize = 64;
    public static int PriorityAddr = 108;
    public const int PrioritySize = 1;
    public static int SyncAddressAddr = 109;
    public const int SyncPacketSize = 2;
    public static int SequenceNumberAddr = 111;
    public const int SeqNumSize = 1;
    public static int OptionsAddr = 112;
    public const int OptionsSize = 1;
    public static int UniverseAddr = 113;
    public const int UniverseSize = 2;

    // DMP Layer
    public static int DmpFlagsAndLengthAddr = 115;
    public static int DmpFlagsAndLengthSize = 2;
    public static readonly byte[] DmpFlagsAndLength = { 0x72, 0x0B }; // SACN_BUFFER_MAX - DMP_FLAGS_AND_LENGTH_ADDR + 0x7000
    public static int VectorDmpSetPropertyAddr = 117;
    public static int VectorDmpSetPropertySize = 1;
    public const byte VectorDmpSetProperty = 0x02;
    public static int DmpAddressAndDataAddr = 118;
    public static int DmpAddressAndDataSize = 1;
    public const byte DmpAddressAndData = 0xa1;
    public static int FirstPropertyAddressAddr = 119;
    public static int FirstPropertyAddressSize = 2;
    public static readonly byte[] FirstPropertyAddress = { 0x00, 0x00 };
    public static int AddressIncAddr = 121;
    public static int AddressIncSize = 2;
    public static readonly byte[] AddressInc = { 0x00, 0x01 };
    public static int PropertyValueCountAddr = 123;
    public static int PropertyValueCountSize = 2;
    public static readonly byte[] PropertyValueCount = { 0x02, 0x01 }; // DMX_SLOTS_MAX + 1
    public static int StartcodeAddr = 125;
    public const int StartcodeSize = 1;
    public const int DmxValuesAddr = 126;
}

/*
#include "Ethernet.h"
#include "sACN.h"

uint8_t mac[] = {0x90, 0xA2, 0xDA, 0x10, 0x14, 0x48}; // MAC Adress of your device
IPAddress ip(10, 101, 1, 201); // IP address of your device
IPAddress dns(10, 101, 1, 100); // DNS address of your device
IPAddress gateway(10, 101, 1, 100); // Gateway address of your device
IPAddress subnet(255, 255, 0, 0); // Subnet mask of your device

EthernetUDP sacn;

// CID fd32aedc-7b94-11e7-bb31-be2e44b06b34
uint8_t id[16] {0xFD, 0x32, 0xAE, 0xDC, 0x7B, 0x94, 0x11, 0xE7, 0xBB, 0x31, 0xBE, 0x2E, 0x44, 0xB0, 0x6B, 0x34};
Source sender(sacn, 1, 100, id, "Arduino", true);

void setup() {
	Serial.begin(9600);
	delay(2000);
	Ethernet.begin(mac, ip, dns, gateway, subnet);
	sender.begin();
	Serial.println("sACN start");
	sender.dmx(1, 255); // send value 255 to DMX slot 1 
	}

void loop() {
	sender.idle();
	}
    */