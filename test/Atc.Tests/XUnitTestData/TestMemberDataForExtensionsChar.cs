using Xunit;

namespace Atc.Tests.XUnitTestData
{
    internal static class TestMemberDataForExtensionsChar
    {
        private const string AllAsciiCharacters = " !\"#$%&\'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
        private const string NonAsciiCharacters = "¦ÇüéâäàåçêëèïîìÄÅÉæÆôöòûùÿÖÜø£Ø×ƒáíóúñÑªº¿®¬½¼¡«»░▒▓│┤ÁÂÀ©╣║╗╝¢¥┐└┴┬├─┼ãÃ╚╔╩╦╠═╬¤ðÐÊËÈıÍÎÏ┘┌█▄¦Ì▀ÓßÔÒõÕµþÞÚÛÙýÝ¯´≡±‗¾¶§÷¸°¨·¹³²■";

        public static TheoryData<bool, char> IsAscii
        {
            get
            {
                var data = new TheoryData<bool, char>();
                foreach (var c in AllAsciiCharacters)
                {
                    data.Add(true, c);
                }

                foreach (var c in NonAsciiCharacters)
                {
                    data.Add(false, c);
                }

                return data;
            }
        }
    }
}
