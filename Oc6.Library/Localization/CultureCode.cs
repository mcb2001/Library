using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Localization
{
    /// <summary>
    /// Default culture codes
    /// </summary>
    public enum CultureCode
    {
        /// <summary>
        ///Afrikaans - South Africa
        ///</summary>
        afZA = 1,

        /// <summary>
        ///Albanian - Albania
        ///</summary>
        sqAL = 2,

        /// <summary>
        ///Arabic - Algeria
        ///</summary>
        arDZ = 3,

        /// <summary>
        ///Arabic - Bahrain
        ///</summary>
        arBH = 4,

        /// <summary>
        ///Arabic - Egypt
        ///</summary>
        arEG = 5,

        /// <summary>
        ///Arabic - Iraq
        ///</summary>
        arIQ = 6,

        /// <summary>
        ///Arabic - Jordan
        ///</summary>
        arJO = 7,

        /// <summary>
        ///Arabic - Kuwait
        ///</summary>
        arKW = 8,

        /// <summary>
        ///Arabic - Lebanon
        ///</summary>
        arLB = 9,

        /// <summary>
        ///Arabic - Libya
        ///</summary>
        arLY = 10,

        /// <summary>
        ///Arabic - Morocco
        ///</summary>
        arMA = 11,

        /// <summary>
        ///Arabic - Oman
        ///</summary>
        arOM = 12,

        /// <summary>
        ///Arabic - Qatar
        ///</summary>
        arQA = 13,

        /// <summary>
        ///Arabic - Saudi Arabia
        ///</summary>
        arSA = 14,

        /// <summary>
        ///Arabic - Syria
        ///</summary>
        arSY = 15,

        /// <summary>
        ///Arabic - Tunisia
        ///</summary>
        arTN = 16,

        /// <summary>
        ///Arabic - United Arab Emirates
        ///</summary>
        arAE = 17,

        /// <summary>
        ///Arabic - Yemen
        ///</summary>
        arYE = 18,

        /// <summary>
        ///Armenian - Armenia
        ///</summary>
        hyAM = 19,

        /// <summary>
        ///Azeri (Cyrillic) - Azerbaijan
        ///</summary>
        CyAzAZ = 20,

        /// <summary>
        ///Azeri (Latin) - Azerbaijan
        ///</summary>
        LtAzAZ = 21,

        /// <summary>
        ///Basque - Basque
        ///</summary>
        euES = 22,

        /// <summary>
        ///Belarusian - Belarus
        ///</summary>
        beBY = 23,

        /// <summary>
        ///Bulgarian - Bulgaria
        ///</summary>
        bgBG = 24,

        /// <summary>
        ///Catalan - Catalan
        ///</summary>
        caES = 25,

        /// <summary>
        ///Chinese - China
        ///</summary>
        zhCN = 26,

        /// <summary>
        ///Chinese - Hong Kong SAR
        ///</summary>
        zhHK = 27,

        /// <summary>
        ///Chinese - Macau SAR
        ///</summary>
        zhMO = 28,

        /// <summary>
        ///Chinese - Singapore
        ///</summary>
        zhSG = 29,

        /// <summary>
        ///Chinese - Taiwan
        ///</summary>
        zhTW = 30,

        /// <summary>
        ///Chinese (Simplified)
        ///</summary>
        zhCHS = 31,

        /// <summary>
        ///Chinese (Traditional)
        ///</summary>
        zhCHT = 32,

        /// <summary>
        ///Croatian - Croatia
        ///</summary>
        hrHR = 33,

        /// <summary>
        ///Czech - Czech Republic
        ///</summary>
        csCZ = 34,

        /// <summary>
        ///Danish - Denmark
        ///</summary>
        daDK = 35,

        /// <summary>
        ///Dhivehi - Maldives
        ///</summary>
        divMV = 36,

        /// <summary>
        ///Dutch - Belgium
        ///</summary>
        nlBE = 37,

        /// <summary>
        ///Dutch - The Netherlands
        ///</summary>
        nlNL = 38,

        /// <summary>
        ///English - Australia
        ///</summary>
        enAU = 39,

        /// <summary>
        ///English - Belize
        ///</summary>
        enBZ = 40,

        /// <summary>
        ///English - Canada
        ///</summary>
        enCA = 41,

        /// <summary>
        ///English - Caribbean
        ///</summary>
        enCB = 42,

        /// <summary>
        ///English - Ireland
        ///</summary>
        enIE = 43,

        /// <summary>
        ///English - Jamaica
        ///</summary>
        enJM = 44,

        /// <summary>
        ///English - New Zealand
        ///</summary>
        enNZ = 45,

        /// <summary>
        ///English - Philippines
        ///</summary>
        enPH = 46,

        /// <summary>
        ///English - South Africa
        ///</summary>
        enZA = 47,

        /// <summary>
        ///English - Trinidad and Tobago
        ///</summary>
        enTT = 48,

        /// <summary>
        ///English - United Kingdom
        ///</summary>
        enGB = 49,

        /// <summary>
        ///English - United States
        ///</summary>
        enUS = 50,

        /// <summary>
        ///English - Zimbabwe
        ///</summary>
        enZW = 51,

        /// <summary>
        ///Estonian - Estonia
        ///</summary>
        etEE = 52,

        /// <summary>
        ///Faroese - Faroe Islands
        ///</summary>
        foFO = 53,

        /// <summary>
        ///Farsi - Iran
        ///</summary>
        faIR = 54,

        /// <summary>
        ///Finnish - Finland
        ///</summary>
        fiFI = 55,

        /// <summary>
        ///French - Belgium
        ///</summary>
        frBE = 56,

        /// <summary>
        ///French - Canada
        ///</summary>
        frCA = 57,

        /// <summary>
        ///French - France
        ///</summary>
        frFR = 58,

        /// <summary>
        ///French - Luxembourg
        ///</summary>
        frLU = 59,

        /// <summary>
        ///French - Monaco
        ///</summary>
        frMC = 60,

        /// <summary>
        ///French - Switzerland
        ///</summary>
        frCH = 61,

        /// <summary>
        ///Galician - Galician
        ///</summary>
        glES = 62,

        /// <summary>
        ///Georgian - Georgia
        ///</summary>
        kaGE = 63,

        /// <summary>
        ///German - Austria
        ///</summary>
        deAT = 64,

        /// <summary>
        ///German - Germany
        ///</summary>
        deDE = 65,

        /// <summary>
        ///German - Liechtenstein
        ///</summary>
        deLI = 66,

        /// <summary>
        ///German - Luxembourg
        ///</summary>
        deLU = 67,

        /// <summary>
        ///German - Switzerland
        ///</summary>
        deCH = 68,

        /// <summary>
        ///Greek - Greece
        ///</summary>
        elGR = 69,

        /// <summary>
        ///Gujarati - India
        ///</summary>
        guIN = 70,

        /// <summary>
        ///Hebrew - Israel
        ///</summary>
        heIL = 71,

        /// <summary>
        ///Hindi - India
        ///</summary>
        hiIN = 72,

        /// <summary>
        ///Hungarian - Hungary
        ///</summary>
        huHU = 73,

        /// <summary>
        ///Icelandic - Iceland
        ///</summary>
        isIS = 74,

        /// <summary>
        ///Indonesian - Indonesia
        ///</summary>
        idID = 75,

        /// <summary>
        ///Italian - Italy
        ///</summary>
        itIT = 76,

        /// <summary>
        ///Italian - Switzerland
        ///</summary>
        itCH = 77,

        /// <summary>
        ///Japanese - Japan
        ///</summary>
        jaJP = 78,

        /// <summary>
        ///Kannada - India
        ///</summary>
        knIN = 79,

        /// <summary>
        ///Kazakh - Kazakhstan
        ///</summary>
        kkKZ = 80,

        /// <summary>
        ///Konkani - India
        ///</summary>
        kokIN = 81,

        /// <summary>
        ///Korean - Korea
        ///</summary>
        koKR = 82,

        /// <summary>
        ///Kyrgyz - Kazakhstan
        ///</summary>
        kyKZ = 83,

        /// <summary>
        ///Latvian - Latvia
        ///</summary>
        lvLV = 84,

        /// <summary>
        ///Lithuanian - Lithuania
        ///</summary>
        ltLT = 85,

        /// <summary>
        ///Macedonian (FYROM)
        ///</summary>
        mkMK = 86,

        /// <summary>
        ///Malay - Brunei
        ///</summary>
        msBN = 87,

        /// <summary>
        ///Malay - Malaysia
        ///</summary>
        msMY = 88,

        /// <summary>
        ///Marathi - India
        ///</summary>
        mrIN = 89,

        /// <summary>
        ///Mongolian - Mongolia
        ///</summary>
        mnMN = 90,

        /// <summary>
        ///Norwegian (Bokmål) - Norway
        ///</summary>
        nbNO = 91,

        /// <summary>
        ///Norwegian (Nynorsk) - Norway
        ///</summary>
        nnNO = 92,

        /// <summary>
        ///Polish - Poland
        ///</summary>
        plPL = 93,

        /// <summary>
        ///Portuguese - Brazil
        ///</summary>
        ptBR = 94,

        /// <summary>
        ///Portuguese - Portugal
        ///</summary>
        ptPT = 95,

        /// <summary>
        ///Punjabi - India
        ///</summary>
        paIN = 96,

        /// <summary>
        ///Romanian - Romania
        ///</summary>
        roRO = 97,

        /// <summary>
        ///Russian - Russia
        ///</summary>
        ruRU = 98,

        /// <summary>
        ///Sanskrit - India
        ///</summary>
        saIN = 99,

        /// <summary>
        ///Serbian (Cyrillic) - Serbia
        ///</summary>
        CySrSP = 100,

        /// <summary>
        ///Serbian (Latin) - Serbia
        ///</summary>
        LtSrSP = 101,

        /// <summary>
        ///Slovak - Slovakia
        ///</summary>
        skSK = 102,

        /// <summary>
        ///Slovenian - Slovenia
        ///</summary>
        slSI = 103,

        /// <summary>
        ///Spanish - Argentina
        ///</summary>
        esAR = 104,

        /// <summary>
        ///Spanish - Bolivia
        ///</summary>
        esBO = 105,

        /// <summary>
        ///Spanish - Chile
        ///</summary>
        esCL = 106,

        /// <summary>
        ///Spanish - Colombia
        ///</summary>
        esCO = 107,

        /// <summary>
        ///Spanish - Costa Rica
        ///</summary>
        esCR = 108,

        /// <summary>
        ///Spanish - Dominican Republic
        ///</summary>
        esDO = 109,

        /// <summary>
        ///Spanish - Ecuador
        ///</summary>
        esEC = 110,

        /// <summary>
        ///Spanish - El Salvador
        ///</summary>
        esSV = 111,

        /// <summary>
        ///Spanish - Guatemala
        ///</summary>
        esGT = 112,

        /// <summary>
        ///Spanish - Honduras
        ///</summary>
        esHN = 113,

        /// <summary>
        ///Spanish - Mexico
        ///</summary>
        esMX = 114,

        /// <summary>
        ///Spanish - Nicaragua
        ///</summary>
        esNI = 115,

        /// <summary>
        ///Spanish - Panama
        ///</summary>
        esPA = 116,

        /// <summary>
        ///Spanish - Paraguay
        ///</summary>
        esPY = 117,

        /// <summary>
        ///Spanish - Peru
        ///</summary>
        esPE = 118,

        /// <summary>
        ///Spanish - Puerto Rico
        ///</summary>
        esPR = 119,

        /// <summary>
        ///Spanish - Spain
        ///</summary>
        esES = 120,

        /// <summary>
        ///Spanish - Uruguay
        ///</summary>
        esUY = 121,

        /// <summary>
        ///Spanish - Venezuela
        ///</summary>
        esVE = 122,

        /// <summary>
        ///Swahili - Kenya
        ///</summary>
        swKE = 123,

        /// <summary>
        ///Swedish - Finland
        ///</summary>
        svFI = 124,

        /// <summary>
        ///Swedish - Sweden
        ///</summary>
        svSE = 125,

        /// <summary>
        ///Syriac - Syria
        ///</summary>
        syrSY = 126,

        /// <summary>
        ///Tamil - India
        ///</summary>
        taIN = 127,

        /// <summary>
        ///Tatar - Russia
        ///</summary>
        ttRU = 128,

        /// <summary>
        ///Telugu - India
        ///</summary>
        teIN = 129,

        /// <summary>
        ///Thai - Thailand
        ///</summary>
        thTH = 130,

        /// <summary>
        ///Turkish - Turkey
        ///</summary>
        trTR = 131,

        /// <summary>
        ///Ukrainian - Ukraine
        ///</summary>
        ukUA = 132,

        /// <summary>
        ///Urdu - Pakistan
        ///</summary>
        urPK = 133,

        /// <summary>
        ///Uzbek (Cyrillic) - Uzbekistan
        ///</summary>
        CyUzUZ = 134,

        /// <summary>
        ///Uzbek (Latin) - Uzbekistan
        ///</summary>
        LtUzUZ = 135,

        /// <summary>
        ///Vietnamese - Vietnam
        ///</summary>
        viVN = 136,
    }
}