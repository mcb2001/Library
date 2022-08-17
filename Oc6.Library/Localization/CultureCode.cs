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
        af_ZA = 1,

        /// <summary>
        ///Albanian - Albania
        ///</summary>
        sq_AL = 2,

        /// <summary>
        ///Arabic - Algeria
        ///</summary>
        ar_DZ = 3,

        /// <summary>
        ///Arabic - Bahrain
        ///</summary>
        ar_BH = 4,

        /// <summary>
        ///Arabic - Egypt
        ///</summary>
        ar_EG = 5,

        /// <summary>
        ///Arabic - Iraq
        ///</summary>
        ar_IQ = 6,

        /// <summary>
        ///Arabic - Jordan
        ///</summary>
        ar_JO = 7,

        /// <summary>
        ///Arabic - Kuwait
        ///</summary>
        ar_KW = 8,

        /// <summary>
        ///Arabic - Lebanon
        ///</summary>
        ar_LB = 9,

        /// <summary>
        ///Arabic - Libya
        ///</summary>
        ar_LY = 10,

        /// <summary>
        ///Arabic - Morocco
        ///</summary>
        ar_MA = 11,

        /// <summary>
        ///Arabic - Oman
        ///</summary>
        ar_OM = 12,

        /// <summary>
        ///Arabic - Qatar
        ///</summary>
        ar_QA = 13,

        /// <summary>
        ///Arabic - Saudi Arabia
        ///</summary>
        ar_SA = 14,

        /// <summary>
        ///Arabic - Syria
        ///</summary>
        ar_SY = 15,

        /// <summary>
        ///Arabic - Tunisia
        ///</summary>
        ar_TN = 16,

        /// <summary>
        ///Arabic - United Arab Emirates
        ///</summary>
        ar_AE = 17,

        /// <summary>
        ///Arabic - Yemen
        ///</summary>
        ar_YE = 18,

        /// <summary>
        ///Armenian - Armenia
        ///</summary>
        hy_AM = 19,

        /// <summary>
        ///Azeri (Cyrillic) - Azerbaijan
        ///</summary>
        Cy_az_AZ = 20,

        /// <summary>
        ///Azeri (Latin) - Azerbaijan
        ///</summary>
        Lt_az_AZ = 21,

        /// <summary>
        ///Basque - Basque
        ///</summary>
        eu_ES = 22,

        /// <summary>
        ///Belarusian - Belarus
        ///</summary>
        be_BY = 23,

        /// <summary>
        ///Bulgarian - Bulgaria
        ///</summary>
        bg_BG = 24,

        /// <summary>
        ///Catalan - Catalan
        ///</summary>
        ca_ES = 25,

        /// <summary>
        ///Chinese - China
        ///</summary>
        zh_CN = 26,

        /// <summary>
        ///Chinese - Hong Kong SAR
        ///</summary>
        zh_HK = 27,

        /// <summary>
        ///Chinese - Macau SAR
        ///</summary>
        zh_MO = 28,

        /// <summary>
        ///Chinese - Singapore
        ///</summary>
        zh_SG = 29,

        /// <summary>
        ///Chinese - Taiwan
        ///</summary>
        zh_TW = 30,

        /// <summary>
        ///Chinese (Simplified)
        ///</summary>
        zh_CHS = 31,

        /// <summary>
        ///Chinese (Traditional)
        ///</summary>
        zh_CHT = 32,

        /// <summary>
        ///Croatian - Croatia
        ///</summary>
        hr_HR = 33,

        /// <summary>
        ///Czech - Czech Republic
        ///</summary>
        cs_CZ = 34,

        /// <summary>
        ///Danish - Denmark
        ///</summary>
        da_DK = 35,

        /// <summary>
        ///Dhivehi - Maldives
        ///</summary>
        div_MV = 36,

        /// <summary>
        ///Dutch - Belgium
        ///</summary>
        nl_BE = 37,

        /// <summary>
        ///Dutch - The Netherlands
        ///</summary>
        nl_NL = 38,

        /// <summary>
        ///English - Australia
        ///</summary>
        en_AU = 39,

        /// <summary>
        ///English - Belize
        ///</summary>
        en_BZ = 40,

        /// <summary>
        ///English - Canada
        ///</summary>
        en_CA = 41,

        /// <summary>
        ///English - Caribbean
        ///</summary>
        en_CB = 42,

        /// <summary>
        ///English - Ireland
        ///</summary>
        en_IE = 43,

        /// <summary>
        ///English - Jamaica
        ///</summary>
        en_JM = 44,

        /// <summary>
        ///English - New Zealand
        ///</summary>
        en_NZ = 45,

        /// <summary>
        ///English - Philippines
        ///</summary>
        en_PH = 46,

        /// <summary>
        ///English - South Africa
        ///</summary>
        en_ZA = 47,

        /// <summary>
        ///English - Trinidad and Tobago
        ///</summary>
        en_TT = 48,

        /// <summary>
        ///English - United Kingdom
        ///</summary>
        en_GB = 49,

        /// <summary>
        ///English - United States
        ///</summary>
        en_US = 50,

        /// <summary>
        ///English - Zimbabwe
        ///</summary>
        en_ZW = 51,

        /// <summary>
        ///Estonian - Estonia
        ///</summary>
        et_EE = 52,

        /// <summary>
        ///Faroese - Faroe Islands
        ///</summary>
        fo_FO = 53,

        /// <summary>
        ///Farsi - Iran
        ///</summary>
        fa_IR = 54,

        /// <summary>
        ///Finnish - Finland
        ///</summary>
        fi_FI = 55,

        /// <summary>
        ///French - Belgium
        ///</summary>
        fr_BE = 56,

        /// <summary>
        ///French - Canada
        ///</summary>
        fr_CA = 57,

        /// <summary>
        ///French - France
        ///</summary>
        fr_FR = 58,

        /// <summary>
        ///French - Luxembourg
        ///</summary>
        fr_LU = 59,

        /// <summary>
        ///French - Monaco
        ///</summary>
        fr_MC = 60,

        /// <summary>
        ///French - Switzerland
        ///</summary>
        fr_CH = 61,

        /// <summary>
        ///Galician - Galician
        ///</summary>
        gl_ES = 62,

        /// <summary>
        ///Georgian - Georgia
        ///</summary>
        ka_GE = 63,

        /// <summary>
        ///German - Austria
        ///</summary>
        de_AT = 64,

        /// <summary>
        ///German - Germany
        ///</summary>
        de_DE = 65,

        /// <summary>
        ///German - Liechtenstein
        ///</summary>
        de_LI = 66,

        /// <summary>
        ///German - Luxembourg
        ///</summary>
        de_LU = 67,

        /// <summary>
        ///German - Switzerland
        ///</summary>
        de_CH = 68,

        /// <summary>
        ///Greek - Greece
        ///</summary>
        el_GR = 69,

        /// <summary>
        ///Gujarati - India
        ///</summary>
        gu_IN = 70,

        /// <summary>
        ///Hebrew - Israel
        ///</summary>
        he_IL = 71,

        /// <summary>
        ///Hindi - India
        ///</summary>
        hi_IN = 72,

        /// <summary>
        ///Hungarian - Hungary
        ///</summary>
        hu_HU = 73,

        /// <summary>
        ///Icelandic - Iceland
        ///</summary>
        is_IS = 74,

        /// <summary>
        ///Indonesian - Indonesia
        ///</summary>
        id_ID = 75,

        /// <summary>
        ///Italian - Italy
        ///</summary>
        it_IT = 76,

        /// <summary>
        ///Italian - Switzerland
        ///</summary>
        it_CH = 77,

        /// <summary>
        ///Japanese - Japan
        ///</summary>
        ja_JP = 78,

        /// <summary>
        ///Kannada - India
        ///</summary>
        kn_IN = 79,

        /// <summary>
        ///Kazakh - Kazakhstan
        ///</summary>
        kk_KZ = 80,

        /// <summary>
        ///Konkani - India
        ///</summary>
        kok_IN = 81,

        /// <summary>
        ///Korean - Korea
        ///</summary>
        ko_KR = 82,

        /// <summary>
        ///Kyrgyz - Kazakhstan
        ///</summary>
        ky_KZ = 83,

        /// <summary>
        ///Latvian - Latvia
        ///</summary>
        lv_LV = 84,

        /// <summary>
        ///Lithuanian - Lithuania
        ///</summary>
        lt_LT = 85,

        /// <summary>
        ///Macedonian (FYROM)
        ///</summary>
        mk_MK = 86,

        /// <summary>
        ///Malay - Brunei
        ///</summary>
        ms_BN = 87,

        /// <summary>
        ///Malay - Malaysia
        ///</summary>
        ms_MY = 88,

        /// <summary>
        ///Marathi - India
        ///</summary>
        mr_IN = 89,

        /// <summary>
        ///Mongolian - Mongolia
        ///</summary>
        mn_MN = 90,

        /// <summary>
        ///Norwegian (Bokmål) - Norway
        ///</summary>
        nb_NO = 91,

        /// <summary>
        ///Norwegian (Nynorsk) - Norway
        ///</summary>
        nn_NO = 92,

        /// <summary>
        ///Polish - Poland
        ///</summary>
        pl_PL = 93,

        /// <summary>
        ///Portuguese - Brazil
        ///</summary>
        pt_BR = 94,

        /// <summary>
        ///Portuguese - Portugal
        ///</summary>
        pt_PT = 95,

        /// <summary>
        ///Punjabi - India
        ///</summary>
        pa_IN = 96,

        /// <summary>
        ///Romanian - Romania
        ///</summary>
        ro_RO = 97,

        /// <summary>
        ///Russian - Russia
        ///</summary>
        ru_RU = 98,

        /// <summary>
        ///Sanskrit - India
        ///</summary>
        sa_IN = 99,

        /// <summary>
        ///Serbian (Cyrillic) - Serbia
        ///</summary>
        Cy_sr_SP = 100,

        /// <summary>
        ///Serbian (Latin) - Serbia
        ///</summary>
        Lt_sr_SP = 101,

        /// <summary>
        ///Slovak - Slovakia
        ///</summary>
        sk_SK = 102,

        /// <summary>
        ///Slovenian - Slovenia
        ///</summary>
        sl_SI = 103,

        /// <summary>
        ///Spanish - Argentina
        ///</summary>
        es_AR = 104,

        /// <summary>
        ///Spanish - Bolivia
        ///</summary>
        es_BO = 105,

        /// <summary>
        ///Spanish - Chile
        ///</summary>
        es_CL = 106,

        /// <summary>
        ///Spanish - Colombia
        ///</summary>
        es_CO = 107,

        /// <summary>
        ///Spanish - Costa Rica
        ///</summary>
        es_CR = 108,

        /// <summary>
        ///Spanish - Dominican Republic
        ///</summary>
        es_DO = 109,

        /// <summary>
        ///Spanish - Ecuador
        ///</summary>
        es_EC = 110,

        /// <summary>
        ///Spanish - El Salvador
        ///</summary>
        es_SV = 111,

        /// <summary>
        ///Spanish - Guatemala
        ///</summary>
        es_GT = 112,

        /// <summary>
        ///Spanish - Honduras
        ///</summary>
        es_HN = 113,

        /// <summary>
        ///Spanish - Mexico
        ///</summary>
        es_MX = 114,

        /// <summary>
        ///Spanish - Nicaragua
        ///</summary>
        es_NI = 115,

        /// <summary>
        ///Spanish - Panama
        ///</summary>
        es_PA = 116,

        /// <summary>
        ///Spanish - Paraguay
        ///</summary>
        es_PY = 117,

        /// <summary>
        ///Spanish - Peru
        ///</summary>
        es_PE = 118,

        /// <summary>
        ///Spanish - Puerto Rico
        ///</summary>
        es_PR = 119,

        /// <summary>
        ///Spanish - Spain
        ///</summary>
        es_ES = 120,

        /// <summary>
        ///Spanish - Uruguay
        ///</summary>
        es_UY = 121,

        /// <summary>
        ///Spanish - Venezuela
        ///</summary>
        es_VE = 122,

        /// <summary>
        ///Swahili - Kenya
        ///</summary>
        sw_KE = 123,

        /// <summary>
        ///Swedish - Finland
        ///</summary>
        sv_FI = 124,

        /// <summary>
        ///Swedish - Sweden
        ///</summary>
        sv_SE = 125,

        /// <summary>
        ///Syriac - Syria
        ///</summary>
        syr_SY = 126,

        /// <summary>
        ///Tamil - India
        ///</summary>
        ta_IN = 127,

        /// <summary>
        ///Tatar - Russia
        ///</summary>
        tt_RU = 128,

        /// <summary>
        ///Telugu - India
        ///</summary>
        te_IN = 129,

        /// <summary>
        ///Thai - Thailand
        ///</summary>
        th_TH = 130,

        /// <summary>
        ///Turkish - Turkey
        ///</summary>
        tr_TR = 131,

        /// <summary>
        ///Ukrainian - Ukraine
        ///</summary>
        uk_UA = 132,

        /// <summary>
        ///Urdu - Pakistan
        ///</summary>
        ur_PK = 133,

        /// <summary>
        ///Uzbek (Cyrillic) - Uzbekistan
        ///</summary>
        Cy_uz_UZ = 134,

        /// <summary>
        ///Uzbek (Latin) - Uzbekistan
        ///</summary>
        Lt_uz_UZ = 135,

        /// <summary>
        ///Vietnamese - Vietnam
        ///</summary>
        vi_VN = 136,
    }
}