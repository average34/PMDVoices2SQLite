namespace PMDVoices2SQLite
{
    public interface IPMDVoice
    {
        byte ALG { get; set; }
        byte AMS1 { get; set; }
        byte AMS2 { get; set; }
        byte AMS3 { get; set; }
        byte AMS4 { get; set; }
        byte AR1 { get; set; }
        byte AR2 { get; set; }
        byte AR3 { get; set; }
        byte AR4 { get; set; }
        byte DR1 { get; set; }
        byte DR2 { get; set; }
        byte DR3 { get; set; }
        byte DR4 { get; set; }
        byte DT1 { get; set; }
        byte DT2 { get; set; }
        byte DT2_1 { get; set; }
        byte DT2_2 { get; set; }
        byte DT2_3 { get; set; }
        byte DT2_4 { get; set; }
        byte DT3 { get; set; }
        byte DT4 { get; set; }
        byte FBL { get; set; }
        byte KS1 { get; set; }
        byte KS2 { get; set; }
        byte KS3 { get; set; }
        byte KS4 { get; set; }
        byte ML1 { get; set; }
        byte ML2 { get; set; }
        byte ML3 { get; set; }
        byte ML4 { get; set; }
        byte NM { get; set; }
        byte RR1 { get; set; }
        byte RR2 { get; set; }
        byte RR3 { get; set; }
        byte RR4 { get; set; }
        byte SL1 { get; set; }
        byte SL2 { get; set; }
        byte SL3 { get; set; }
        byte SL4 { get; set; }
        byte SR1 { get; set; }
        byte SR2 { get; set; }
        byte SR3 { get; set; }
        byte SR4 { get; set; }
        byte TL1 { get; set; }
        byte TL2 { get; set; }
        byte TL3 { get; set; }
        byte TL4 { get; set; }
        bool CoreEquals(IPMDVoice obj);
    }
}