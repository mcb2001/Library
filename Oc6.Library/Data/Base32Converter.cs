using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Data
{
    public class Base32Converter
    {
        private const int x0 = 0b11111000;

        private const int x1a = 0b00000111;
        private const int x1b = 0b11000000;

        private const int x2 = 0b00111110;

        private const int x3a = 0b00000001;
        private const int x3b = 0b11110000;

        private const int x4a = 0b00001111;
        private const int x4b = 0b10000000;

        private const int x5 = 0b01111100;

        private const int x6a = 0b00000011;
        private const int x6b = 0b11100000;

        private const int x7 = 0b00011111;

        private const char Padding = '=';

        public static string Encode(byte[] data)
            => Convert(Enumerate(PadAndClode(data)).Select(x => GetChar(x)), data.Length);

        public static byte[] Decode(string text)
        {
            Span<char> chars = text.ToCharArray();

            throw new NotImplementedException();
        }

        private static char GetChar(int i)
            => i switch
            {
                0 => 'A',
                1 => 'B',
                2 => 'C',
                3 => 'D',
                4 => 'E',
                5 => 'F',
                6 => 'G',
                7 => 'H',
                8 => 'I',
                9 => 'J',
                10 => 'K',
                11 => 'L',
                12 => 'M',
                13 => 'N',
                14 => 'O',
                15 => 'P',
                16 => 'Q',
                17 => 'R',
                18 => 'S',
                19 => 'T',
                20 => 'U',
                21 => 'V',
                22 => 'W',
                23 => 'X',
                24 => 'Y',
                25 => 'Z',
                26 => '2',
                27 => '3',
                28 => '4',
                29 => '5',
                30 => '6',
                31 => '7',
                _ => throw new NotSupportedException(),
            };

        private static int GetValue(char c)
            => c switch
            {
                'A' => 0,
                'B' => 1,
                'C' => 2,
                'D' => 3,
                'E' => 4,
                'F' => 5,
                'G' => 6,
                'H' => 7,
                'I' => 8,
                'J' => 9,
                'K' => 10,
                'L' => 11,
                'M' => 12,
                'N' => 13,
                'O' => 14,
                'P' => 15,
                'Q' => 16,
                'R' => 17,
                'S' => 18,
                'T' => 19,
                'U' => 20,
                'V' => 21,
                'W' => 22,
                'X' => 23,
                'Y' => 24,
                'Z' => 25,
                '2' => 26,
                '3' => 27,
                '4' => 28,
                '5' => 29,
                '6' => 30,
                '7' => 31,
                _ => throw new NotSupportedException(),
            };

        private static string Convert(IEnumerable<char> chars, int lenght)
        {
            var paddingCount = GetPaddingCount(lenght);

            Span<char> array = chars.ToArray();

            for (int i = 0; i < paddingCount; i++)
            {
                array[^(i + 1)] = Padding;
            }

            return new string(array);
        }

        private static int GetPaddingCount(int length)
            => (length % 5) switch
            {
                0 => 0,
                1 => 6,
                2 => 4,
                3 => 3,
                4 => 1,
                _ => throw new NotSupportedException(),
            };

        private static IEnumerable<int> Enumerate(byte[] data)
        {
            for (int i = 0; i < data.Length; i += 5)
            {
                yield return ShiftAndMask(data[i + 0], x0, 3);

                yield return Combine(ShiftAndMask(data[i + 0], x1a, -2), ShiftAndMask(data[i + 1], x1b, 6));

                yield return ShiftAndMask(data[i + 1], x2, 1);

                yield return Combine(ShiftAndMask(data[i + 1], x3a, -4), ShiftAndMask(data[i + 2], x3b, 4));

                yield return Combine(ShiftAndMask(data[i + 2], x4a, -1), ShiftAndMask(data[i + 3], x4b, 7));

                yield return ShiftAndMask(data[i + 3], x5, 2);

                yield return Combine(ShiftAndMask(data[i + 3], x6a, -3), ShiftAndMask(data[i + 4], x6b, 5));

                yield return ShiftAndMask(data[i + 4], x7, 0);
            }
        }

        private static int Combine(int a, int b)
            => a | b;

        private static int ShiftAndMask(int value, int mask, int pad)
            => pad >= 0 ? (value & mask) >> pad : (value & mask) << -pad;

        private static byte[] PadAndClode(byte[] data)
        {
            int length = data.Length % 5 == 0 ? data.Length : (5 - data.Length % 5) + data.Length;

            byte[] padded = new byte[length];

            Array.Copy(data, 0, padded, 0, data.Length);

            return padded;
        }
    }
}
