// Decompiled with JetBrains decompiler
// Type: AngleSharp.Html.HtmlEntityService
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using AngleSharp.Extensions;
using AngleSharp.Services;
using System.Collections.Generic;

namespace AngleSharp.Html
{
  public sealed class HtmlEntityService : IEntityProvider
  {
    private readonly Dictionary<char, Dictionary<string, string>> _entities;
    public static readonly IEntityProvider Resolver = (IEntityProvider) new HtmlEntityService();

    private HtmlEntityService() => this._entities = new Dictionary<char, Dictionary<string, string>>()
    {
      {
        'a',
        this.GetSymbolLittleA()
      },
      {
        'A',
        this.GetSymbolBigA()
      },
      {
        'b',
        this.GetSymbolLittleB()
      },
      {
        'B',
        this.GetSymbolBigB()
      },
      {
        'c',
        this.GetSymbolLittleC()
      },
      {
        'C',
        this.GetSymbolBigC()
      },
      {
        'd',
        this.GetSymbolLittleD()
      },
      {
        'D',
        this.GetSymbolBigD()
      },
      {
        'e',
        this.GetSymbolLittleE()
      },
      {
        'E',
        this.GetSymbolBigE()
      },
      {
        'f',
        this.GetSymbolLittleF()
      },
      {
        'F',
        this.GetSymbolBigF()
      },
      {
        'g',
        this.GetSymbolLittleG()
      },
      {
        'G',
        this.GetSymbolBigG()
      },
      {
        'h',
        this.GetSymbolLittleH()
      },
      {
        'H',
        this.GetSymbolBigH()
      },
      {
        'i',
        this.GetSymbolLittleI()
      },
      {
        'I',
        this.GetSymbolBigI()
      },
      {
        'j',
        this.GetSymbolLittleJ()
      },
      {
        'J',
        this.GetSymbolBigJ()
      },
      {
        'k',
        this.GetSymbolLittleK()
      },
      {
        'K',
        this.GetSymbolBigK()
      },
      {
        'l',
        this.GetSymbolLittleL()
      },
      {
        'L',
        this.GetSymbolBigL()
      },
      {
        'm',
        this.GetSymbolLittleM()
      },
      {
        'M',
        this.GetSymbolBigM()
      },
      {
        'n',
        this.GetSymbolLittleN()
      },
      {
        'N',
        this.GetSymbolBigN()
      },
      {
        'o',
        this.GetSymbolLittleO()
      },
      {
        'O',
        this.GetSymbolBigO()
      },
      {
        'p',
        this.GetSymbolLittleP()
      },
      {
        'P',
        this.GetSymbolBigP()
      },
      {
        'q',
        this.GetSymbolLittleQ()
      },
      {
        'Q',
        this.GetSymbolBigQ()
      },
      {
        'r',
        this.GetSymbolLittleR()
      },
      {
        'R',
        this.GetSymbolBigR()
      },
      {
        's',
        this.GetSymbolLittleS()
      },
      {
        'S',
        this.GetSymbolBigS()
      },
      {
        't',
        this.GetSymbolLittleT()
      },
      {
        'T',
        this.GetSymbolBigT()
      },
      {
        'u',
        this.GetSymbolLittleU()
      },
      {
        'U',
        this.GetSymbolBigU()
      },
      {
        'v',
        this.GetSymbolLittleV()
      },
      {
        'V',
        this.GetSymbolBigV()
      },
      {
        'w',
        this.GetSymbolLittleW()
      },
      {
        'W',
        this.GetSymbolBigW()
      },
      {
        'x',
        this.GetSymbolLittleX()
      },
      {
        'X',
        this.GetSymbolBigX()
      },
      {
        'y',
        this.GetSymbolLittleY()
      },
      {
        'Y',
        this.GetSymbolBigY()
      },
      {
        'z',
        this.GetSymbolLittleZ()
      },
      {
        'Z',
        this.GetSymbolBigZ()
      }
    };

    private Dictionary<string, string> GetSymbolLittleA()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddBoth(symbols, "aacute;", HtmlEntityService.Convert(225));
      HtmlEntityService.AddSingle(symbols, "abreve;", HtmlEntityService.Convert(259));
      HtmlEntityService.AddSingle(symbols, "ac;", HtmlEntityService.Convert(8766));
      HtmlEntityService.AddSingle(symbols, "acd;", HtmlEntityService.Convert(8767));
      HtmlEntityService.AddSingle(symbols, "acE;", HtmlEntityService.Convert(8766, 819));
      HtmlEntityService.AddBoth(symbols, "acirc;", HtmlEntityService.Convert(226));
      HtmlEntityService.AddBoth(symbols, "acute;", HtmlEntityService.Convert(180));
      HtmlEntityService.AddSingle(symbols, "acy;", HtmlEntityService.Convert(1072));
      HtmlEntityService.AddBoth(symbols, "aelig;", HtmlEntityService.Convert(230));
      HtmlEntityService.AddSingle(symbols, "af;", HtmlEntityService.Convert(8289));
      HtmlEntityService.AddSingle(symbols, "afr;", HtmlEntityService.Convert(120094));
      HtmlEntityService.AddBoth(symbols, "agrave;", HtmlEntityService.Convert(224));
      HtmlEntityService.AddSingle(symbols, "alefsym;", HtmlEntityService.Convert(8501));
      HtmlEntityService.AddSingle(symbols, "aleph;", HtmlEntityService.Convert(8501));
      HtmlEntityService.AddSingle(symbols, "alpha;", HtmlEntityService.Convert(945));
      HtmlEntityService.AddSingle(symbols, "amacr;", HtmlEntityService.Convert(257));
      HtmlEntityService.AddSingle(symbols, "amalg;", HtmlEntityService.Convert(10815));
      HtmlEntityService.AddBoth(symbols, "amp;", HtmlEntityService.Convert(38));
      HtmlEntityService.AddSingle(symbols, "and;", HtmlEntityService.Convert(8743));
      HtmlEntityService.AddSingle(symbols, "andand;", HtmlEntityService.Convert(10837));
      HtmlEntityService.AddSingle(symbols, "andd;", HtmlEntityService.Convert(10844));
      HtmlEntityService.AddSingle(symbols, "andslope;", HtmlEntityService.Convert(10840));
      HtmlEntityService.AddSingle(symbols, "andv;", HtmlEntityService.Convert(10842));
      HtmlEntityService.AddSingle(symbols, "ang;", HtmlEntityService.Convert(8736));
      HtmlEntityService.AddSingle(symbols, "ange;", HtmlEntityService.Convert(10660));
      HtmlEntityService.AddSingle(symbols, "angle;", HtmlEntityService.Convert(8736));
      HtmlEntityService.AddSingle(symbols, "angmsd;", HtmlEntityService.Convert(8737));
      HtmlEntityService.AddSingle(symbols, "angmsdaa;", HtmlEntityService.Convert(10664));
      HtmlEntityService.AddSingle(symbols, "angmsdab;", HtmlEntityService.Convert(10665));
      HtmlEntityService.AddSingle(symbols, "angmsdac;", HtmlEntityService.Convert(10666));
      HtmlEntityService.AddSingle(symbols, "angmsdad;", HtmlEntityService.Convert(10667));
      HtmlEntityService.AddSingle(symbols, "angmsdae;", HtmlEntityService.Convert(10668));
      HtmlEntityService.AddSingle(symbols, "angmsdaf;", HtmlEntityService.Convert(10669));
      HtmlEntityService.AddSingle(symbols, "angmsdag;", HtmlEntityService.Convert(10670));
      HtmlEntityService.AddSingle(symbols, "angmsdah;", HtmlEntityService.Convert(10671));
      HtmlEntityService.AddSingle(symbols, "angrt;", HtmlEntityService.Convert(8735));
      HtmlEntityService.AddSingle(symbols, "angrtvb;", HtmlEntityService.Convert(8894));
      HtmlEntityService.AddSingle(symbols, "angrtvbd;", HtmlEntityService.Convert(10653));
      HtmlEntityService.AddSingle(symbols, "angsph;", HtmlEntityService.Convert(8738));
      HtmlEntityService.AddSingle(symbols, "angst;", HtmlEntityService.Convert(197));
      HtmlEntityService.AddSingle(symbols, "angzarr;", HtmlEntityService.Convert(9084));
      HtmlEntityService.AddSingle(symbols, "aogon;", HtmlEntityService.Convert(261));
      HtmlEntityService.AddSingle(symbols, "aopf;", HtmlEntityService.Convert(120146));
      HtmlEntityService.AddSingle(symbols, "ap;", HtmlEntityService.Convert(8776));
      HtmlEntityService.AddSingle(symbols, "apacir;", HtmlEntityService.Convert(10863));
      HtmlEntityService.AddSingle(symbols, "apE;", HtmlEntityService.Convert(10864));
      HtmlEntityService.AddSingle(symbols, "ape;", HtmlEntityService.Convert(8778));
      HtmlEntityService.AddSingle(symbols, "apid;", HtmlEntityService.Convert(8779));
      HtmlEntityService.AddSingle(symbols, "apos;", HtmlEntityService.Convert(39));
      HtmlEntityService.AddSingle(symbols, "approx;", HtmlEntityService.Convert(8776));
      HtmlEntityService.AddSingle(symbols, "approxeq;", HtmlEntityService.Convert(8778));
      HtmlEntityService.AddBoth(symbols, "aring;", HtmlEntityService.Convert(229));
      HtmlEntityService.AddSingle(symbols, "ascr;", HtmlEntityService.Convert(119990));
      HtmlEntityService.AddSingle(symbols, "ast;", HtmlEntityService.Convert(42));
      HtmlEntityService.AddSingle(symbols, "asymp;", HtmlEntityService.Convert(8776));
      HtmlEntityService.AddSingle(symbols, "asympeq;", HtmlEntityService.Convert(8781));
      HtmlEntityService.AddBoth(symbols, "atilde;", HtmlEntityService.Convert(227));
      HtmlEntityService.AddBoth(symbols, "auml;", HtmlEntityService.Convert(228));
      HtmlEntityService.AddSingle(symbols, "awconint;", HtmlEntityService.Convert(8755));
      HtmlEntityService.AddSingle(symbols, "awint;", HtmlEntityService.Convert(10769));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigA()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Aogon;", HtmlEntityService.Convert(260));
      HtmlEntityService.AddSingle(symbols, "Aopf;", HtmlEntityService.Convert(120120));
      HtmlEntityService.AddSingle(symbols, "ApplyFunction;", HtmlEntityService.Convert(8289));
      HtmlEntityService.AddBoth(symbols, "Aring;", HtmlEntityService.Convert(197));
      HtmlEntityService.AddSingle(symbols, "Ascr;", HtmlEntityService.Convert(119964));
      HtmlEntityService.AddSingle(symbols, "Assign;", HtmlEntityService.Convert(8788));
      HtmlEntityService.AddBoth(symbols, "Atilde;", HtmlEntityService.Convert(195));
      HtmlEntityService.AddBoth(symbols, "Auml;", HtmlEntityService.Convert(196));
      HtmlEntityService.AddBoth(symbols, "Aacute;", HtmlEntityService.Convert(193));
      HtmlEntityService.AddSingle(symbols, "Abreve;", HtmlEntityService.Convert(258));
      HtmlEntityService.AddBoth(symbols, "Acirc;", HtmlEntityService.Convert(194));
      HtmlEntityService.AddSingle(symbols, "Acy;", HtmlEntityService.Convert(1040));
      HtmlEntityService.AddBoth(symbols, "AElig;", HtmlEntityService.Convert(198));
      HtmlEntityService.AddSingle(symbols, "Afr;", HtmlEntityService.Convert(120068));
      HtmlEntityService.AddBoth(symbols, "Agrave;", HtmlEntityService.Convert(192));
      HtmlEntityService.AddSingle(symbols, "Alpha;", HtmlEntityService.Convert(913));
      HtmlEntityService.AddSingle(symbols, "Amacr;", HtmlEntityService.Convert(256));
      HtmlEntityService.AddBoth(symbols, "AMP;", HtmlEntityService.Convert(38));
      HtmlEntityService.AddSingle(symbols, "And;", HtmlEntityService.Convert(10835));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleB()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "backcong;", HtmlEntityService.Convert(8780));
      HtmlEntityService.AddSingle(symbols, "backepsilon;", HtmlEntityService.Convert(1014));
      HtmlEntityService.AddSingle(symbols, "backprime;", HtmlEntityService.Convert(8245));
      HtmlEntityService.AddSingle(symbols, "backsim;", HtmlEntityService.Convert(8765));
      HtmlEntityService.AddSingle(symbols, "backsimeq;", HtmlEntityService.Convert(8909));
      HtmlEntityService.AddSingle(symbols, "barvee;", HtmlEntityService.Convert(8893));
      HtmlEntityService.AddSingle(symbols, "barwed;", HtmlEntityService.Convert(8965));
      HtmlEntityService.AddSingle(symbols, "barwedge;", HtmlEntityService.Convert(8965));
      HtmlEntityService.AddSingle(symbols, "bbrk;", HtmlEntityService.Convert(9141));
      HtmlEntityService.AddSingle(symbols, "bbrktbrk;", HtmlEntityService.Convert(9142));
      HtmlEntityService.AddSingle(symbols, "bcong;", HtmlEntityService.Convert(8780));
      HtmlEntityService.AddSingle(symbols, "bcy;", HtmlEntityService.Convert(1073));
      HtmlEntityService.AddSingle(symbols, "bdquo;", HtmlEntityService.Convert(8222));
      HtmlEntityService.AddSingle(symbols, "becaus;", HtmlEntityService.Convert(8757));
      HtmlEntityService.AddSingle(symbols, "because;", HtmlEntityService.Convert(8757));
      HtmlEntityService.AddSingle(symbols, "bemptyv;", HtmlEntityService.Convert(10672));
      HtmlEntityService.AddSingle(symbols, "bepsi;", HtmlEntityService.Convert(1014));
      HtmlEntityService.AddSingle(symbols, "bernou;", HtmlEntityService.Convert(8492));
      HtmlEntityService.AddSingle(symbols, "beta;", HtmlEntityService.Convert(946));
      HtmlEntityService.AddSingle(symbols, "beth;", HtmlEntityService.Convert(8502));
      HtmlEntityService.AddSingle(symbols, "between;", HtmlEntityService.Convert(8812));
      HtmlEntityService.AddSingle(symbols, "bfr;", HtmlEntityService.Convert(120095));
      HtmlEntityService.AddSingle(symbols, "bigcap;", HtmlEntityService.Convert(8898));
      HtmlEntityService.AddSingle(symbols, "bigcirc;", HtmlEntityService.Convert(9711));
      HtmlEntityService.AddSingle(symbols, "bigcup;", HtmlEntityService.Convert(8899));
      HtmlEntityService.AddSingle(symbols, "bigodot;", HtmlEntityService.Convert(10752));
      HtmlEntityService.AddSingle(symbols, "bigoplus;", HtmlEntityService.Convert(10753));
      HtmlEntityService.AddSingle(symbols, "bigotimes;", HtmlEntityService.Convert(10754));
      HtmlEntityService.AddSingle(symbols, "bigsqcup;", HtmlEntityService.Convert(10758));
      HtmlEntityService.AddSingle(symbols, "bigstar;", HtmlEntityService.Convert(9733));
      HtmlEntityService.AddSingle(symbols, "bigtriangledown;", HtmlEntityService.Convert(9661));
      HtmlEntityService.AddSingle(symbols, "bigtriangleup;", HtmlEntityService.Convert(9651));
      HtmlEntityService.AddSingle(symbols, "biguplus;", HtmlEntityService.Convert(10756));
      HtmlEntityService.AddSingle(symbols, "bigvee;", HtmlEntityService.Convert(8897));
      HtmlEntityService.AddSingle(symbols, "bigwedge;", HtmlEntityService.Convert(8896));
      HtmlEntityService.AddSingle(symbols, "bkarow;", HtmlEntityService.Convert(10509));
      HtmlEntityService.AddSingle(symbols, "blacklozenge;", HtmlEntityService.Convert(10731));
      HtmlEntityService.AddSingle(symbols, "blacksquare;", HtmlEntityService.Convert(9642));
      HtmlEntityService.AddSingle(symbols, "blacktriangle;", HtmlEntityService.Convert(9652));
      HtmlEntityService.AddSingle(symbols, "blacktriangledown;", HtmlEntityService.Convert(9662));
      HtmlEntityService.AddSingle(symbols, "blacktriangleleft;", HtmlEntityService.Convert(9666));
      HtmlEntityService.AddSingle(symbols, "blacktriangleright;", HtmlEntityService.Convert(9656));
      HtmlEntityService.AddSingle(symbols, "blank;", HtmlEntityService.Convert(9251));
      HtmlEntityService.AddSingle(symbols, "blk12;", HtmlEntityService.Convert(9618));
      HtmlEntityService.AddSingle(symbols, "blk14;", HtmlEntityService.Convert(9617));
      HtmlEntityService.AddSingle(symbols, "blk34;", HtmlEntityService.Convert(9619));
      HtmlEntityService.AddSingle(symbols, "block;", HtmlEntityService.Convert(9608));
      HtmlEntityService.AddSingle(symbols, "bne;", HtmlEntityService.Convert(61, 8421));
      HtmlEntityService.AddSingle(symbols, "bnequiv;", HtmlEntityService.Convert(8801, 8421));
      HtmlEntityService.AddSingle(symbols, "bNot;", HtmlEntityService.Convert(10989));
      HtmlEntityService.AddSingle(symbols, "bnot;", HtmlEntityService.Convert(8976));
      HtmlEntityService.AddSingle(symbols, "bopf;", HtmlEntityService.Convert(120147));
      HtmlEntityService.AddSingle(symbols, "bot;", HtmlEntityService.Convert(8869));
      HtmlEntityService.AddSingle(symbols, "bottom;", HtmlEntityService.Convert(8869));
      HtmlEntityService.AddSingle(symbols, "bowtie;", HtmlEntityService.Convert(8904));
      HtmlEntityService.AddSingle(symbols, "boxbox;", HtmlEntityService.Convert(10697));
      HtmlEntityService.AddSingle(symbols, "boxDL;", HtmlEntityService.Convert(9559));
      HtmlEntityService.AddSingle(symbols, "boxDl;", HtmlEntityService.Convert(9558));
      HtmlEntityService.AddSingle(symbols, "boxdL;", HtmlEntityService.Convert(9557));
      HtmlEntityService.AddSingle(symbols, "boxdl;", HtmlEntityService.Convert(9488));
      HtmlEntityService.AddSingle(symbols, "boxDR;", HtmlEntityService.Convert(9556));
      HtmlEntityService.AddSingle(symbols, "boxDr;", HtmlEntityService.Convert(9555));
      HtmlEntityService.AddSingle(symbols, "boxdR;", HtmlEntityService.Convert(9554));
      HtmlEntityService.AddSingle(symbols, "boxdr;", HtmlEntityService.Convert(9484));
      HtmlEntityService.AddSingle(symbols, "boxH;", HtmlEntityService.Convert(9552));
      HtmlEntityService.AddSingle(symbols, "boxh;", HtmlEntityService.Convert(9472));
      HtmlEntityService.AddSingle(symbols, "boxHD;", HtmlEntityService.Convert(9574));
      HtmlEntityService.AddSingle(symbols, "boxHd;", HtmlEntityService.Convert(9572));
      HtmlEntityService.AddSingle(symbols, "boxhD;", HtmlEntityService.Convert(9573));
      HtmlEntityService.AddSingle(symbols, "boxhd;", HtmlEntityService.Convert(9516));
      HtmlEntityService.AddSingle(symbols, "boxHU;", HtmlEntityService.Convert(9577));
      HtmlEntityService.AddSingle(symbols, "boxHu;", HtmlEntityService.Convert(9575));
      HtmlEntityService.AddSingle(symbols, "boxhU;", HtmlEntityService.Convert(9576));
      HtmlEntityService.AddSingle(symbols, "boxhu;", HtmlEntityService.Convert(9524));
      HtmlEntityService.AddSingle(symbols, "boxminus;", HtmlEntityService.Convert(8863));
      HtmlEntityService.AddSingle(symbols, "boxplus;", HtmlEntityService.Convert(8862));
      HtmlEntityService.AddSingle(symbols, "boxtimes;", HtmlEntityService.Convert(8864));
      HtmlEntityService.AddSingle(symbols, "boxUL;", HtmlEntityService.Convert(9565));
      HtmlEntityService.AddSingle(symbols, "boxUl;", HtmlEntityService.Convert(9564));
      HtmlEntityService.AddSingle(symbols, "boxuL;", HtmlEntityService.Convert(9563));
      HtmlEntityService.AddSingle(symbols, "boxul;", HtmlEntityService.Convert(9496));
      HtmlEntityService.AddSingle(symbols, "boxUR;", HtmlEntityService.Convert(9562));
      HtmlEntityService.AddSingle(symbols, "boxUr;", HtmlEntityService.Convert(9561));
      HtmlEntityService.AddSingle(symbols, "boxuR;", HtmlEntityService.Convert(9560));
      HtmlEntityService.AddSingle(symbols, "boxur;", HtmlEntityService.Convert(9492));
      HtmlEntityService.AddSingle(symbols, "boxV;", HtmlEntityService.Convert(9553));
      HtmlEntityService.AddSingle(symbols, "boxv;", HtmlEntityService.Convert(9474));
      HtmlEntityService.AddSingle(symbols, "boxVH;", HtmlEntityService.Convert(9580));
      HtmlEntityService.AddSingle(symbols, "boxVh;", HtmlEntityService.Convert(9579));
      HtmlEntityService.AddSingle(symbols, "boxvH;", HtmlEntityService.Convert(9578));
      HtmlEntityService.AddSingle(symbols, "boxvh;", HtmlEntityService.Convert(9532));
      HtmlEntityService.AddSingle(symbols, "boxVL;", HtmlEntityService.Convert(9571));
      HtmlEntityService.AddSingle(symbols, "boxVl;", HtmlEntityService.Convert(9570));
      HtmlEntityService.AddSingle(symbols, "boxvL;", HtmlEntityService.Convert(9569));
      HtmlEntityService.AddSingle(symbols, "boxvl;", HtmlEntityService.Convert(9508));
      HtmlEntityService.AddSingle(symbols, "boxVR;", HtmlEntityService.Convert(9568));
      HtmlEntityService.AddSingle(symbols, "boxVr;", HtmlEntityService.Convert(9567));
      HtmlEntityService.AddSingle(symbols, "boxvR;", HtmlEntityService.Convert(9566));
      HtmlEntityService.AddSingle(symbols, "boxvr;", HtmlEntityService.Convert(9500));
      HtmlEntityService.AddSingle(symbols, "bprime;", HtmlEntityService.Convert(8245));
      HtmlEntityService.AddSingle(symbols, "breve;", HtmlEntityService.Convert(728));
      HtmlEntityService.AddBoth(symbols, "brvbar;", HtmlEntityService.Convert(166));
      HtmlEntityService.AddSingle(symbols, "bscr;", HtmlEntityService.Convert(119991));
      HtmlEntityService.AddSingle(symbols, "bsemi;", HtmlEntityService.Convert(8271));
      HtmlEntityService.AddSingle(symbols, "bsim;", HtmlEntityService.Convert(8765));
      HtmlEntityService.AddSingle(symbols, "bsime;", HtmlEntityService.Convert(8909));
      HtmlEntityService.AddSingle(symbols, "bsol;", HtmlEntityService.Convert(92));
      HtmlEntityService.AddSingle(symbols, "bsolb;", HtmlEntityService.Convert(10693));
      HtmlEntityService.AddSingle(symbols, "bsolhsub;", HtmlEntityService.Convert(10184));
      HtmlEntityService.AddSingle(symbols, "bull;", HtmlEntityService.Convert(8226));
      HtmlEntityService.AddSingle(symbols, "bullet;", HtmlEntityService.Convert(8226));
      HtmlEntityService.AddSingle(symbols, "bump;", HtmlEntityService.Convert(8782));
      HtmlEntityService.AddSingle(symbols, "bumpE;", HtmlEntityService.Convert(10926));
      HtmlEntityService.AddSingle(symbols, "bumpe;", HtmlEntityService.Convert(8783));
      HtmlEntityService.AddSingle(symbols, "bumpeq;", HtmlEntityService.Convert(8783));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigB()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Backslash;", HtmlEntityService.Convert(8726));
      HtmlEntityService.AddSingle(symbols, "Barv;", HtmlEntityService.Convert(10983));
      HtmlEntityService.AddSingle(symbols, "Barwed;", HtmlEntityService.Convert(8966));
      HtmlEntityService.AddSingle(symbols, "Bcy;", HtmlEntityService.Convert(1041));
      HtmlEntityService.AddSingle(symbols, "Because;", HtmlEntityService.Convert(8757));
      HtmlEntityService.AddSingle(symbols, "Bernoullis;", HtmlEntityService.Convert(8492));
      HtmlEntityService.AddSingle(symbols, "Beta;", HtmlEntityService.Convert(914));
      HtmlEntityService.AddSingle(symbols, "Bfr;", HtmlEntityService.Convert(120069));
      HtmlEntityService.AddSingle(symbols, "Bopf;", HtmlEntityService.Convert(120121));
      HtmlEntityService.AddSingle(symbols, "Breve;", HtmlEntityService.Convert(728));
      HtmlEntityService.AddSingle(symbols, "Bscr;", HtmlEntityService.Convert(8492));
      HtmlEntityService.AddSingle(symbols, "Bumpeq;", HtmlEntityService.Convert(8782));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleC()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "cacute;", HtmlEntityService.Convert(263));
      HtmlEntityService.AddSingle(symbols, "cap;", HtmlEntityService.Convert(8745));
      HtmlEntityService.AddSingle(symbols, "capand;", HtmlEntityService.Convert(10820));
      HtmlEntityService.AddSingle(symbols, "capbrcup;", HtmlEntityService.Convert(10825));
      HtmlEntityService.AddSingle(symbols, "capcap;", HtmlEntityService.Convert(10827));
      HtmlEntityService.AddSingle(symbols, "capcup;", HtmlEntityService.Convert(10823));
      HtmlEntityService.AddSingle(symbols, "capdot;", HtmlEntityService.Convert(10816));
      HtmlEntityService.AddSingle(symbols, "caps;", HtmlEntityService.Convert(8745, 65024));
      HtmlEntityService.AddSingle(symbols, "caret;", HtmlEntityService.Convert(8257));
      HtmlEntityService.AddSingle(symbols, "caron;", HtmlEntityService.Convert(711));
      HtmlEntityService.AddSingle(symbols, "ccaps;", HtmlEntityService.Convert(10829));
      HtmlEntityService.AddSingle(symbols, "ccaron;", HtmlEntityService.Convert(269));
      HtmlEntityService.AddBoth(symbols, "ccedil;", HtmlEntityService.Convert(231));
      HtmlEntityService.AddSingle(symbols, "ccirc;", HtmlEntityService.Convert(265));
      HtmlEntityService.AddSingle(symbols, "ccups;", HtmlEntityService.Convert(10828));
      HtmlEntityService.AddSingle(symbols, "ccupssm;", HtmlEntityService.Convert(10832));
      HtmlEntityService.AddSingle(symbols, "cdot;", HtmlEntityService.Convert(267));
      HtmlEntityService.AddBoth(symbols, "cedil;", HtmlEntityService.Convert(184));
      HtmlEntityService.AddSingle(symbols, "cemptyv;", HtmlEntityService.Convert(10674));
      HtmlEntityService.AddBoth(symbols, "cent;", HtmlEntityService.Convert(162));
      HtmlEntityService.AddSingle(symbols, "centerdot;", HtmlEntityService.Convert(183));
      HtmlEntityService.AddSingle(symbols, "cfr;", HtmlEntityService.Convert(120096));
      HtmlEntityService.AddSingle(symbols, "chcy;", HtmlEntityService.Convert(1095));
      HtmlEntityService.AddSingle(symbols, "check;", HtmlEntityService.Convert(10003));
      HtmlEntityService.AddSingle(symbols, "checkmark;", HtmlEntityService.Convert(10003));
      HtmlEntityService.AddSingle(symbols, "chi;", HtmlEntityService.Convert(967));
      HtmlEntityService.AddSingle(symbols, "cir;", HtmlEntityService.Convert(9675));
      HtmlEntityService.AddSingle(symbols, "circ;", HtmlEntityService.Convert(710));
      HtmlEntityService.AddSingle(symbols, "circeq;", HtmlEntityService.Convert(8791));
      HtmlEntityService.AddSingle(symbols, "circlearrowleft;", HtmlEntityService.Convert(8634));
      HtmlEntityService.AddSingle(symbols, "circlearrowright;", HtmlEntityService.Convert(8635));
      HtmlEntityService.AddSingle(symbols, "circledast;", HtmlEntityService.Convert(8859));
      HtmlEntityService.AddSingle(symbols, "circledcirc;", HtmlEntityService.Convert(8858));
      HtmlEntityService.AddSingle(symbols, "circleddash;", HtmlEntityService.Convert(8861));
      HtmlEntityService.AddSingle(symbols, "circledR;", HtmlEntityService.Convert(174));
      HtmlEntityService.AddSingle(symbols, "circledS;", HtmlEntityService.Convert(9416));
      HtmlEntityService.AddSingle(symbols, "cirE;", HtmlEntityService.Convert(10691));
      HtmlEntityService.AddSingle(symbols, "cire;", HtmlEntityService.Convert(8791));
      HtmlEntityService.AddSingle(symbols, "cirfnint;", HtmlEntityService.Convert(10768));
      HtmlEntityService.AddSingle(symbols, "cirmid;", HtmlEntityService.Convert(10991));
      HtmlEntityService.AddSingle(symbols, "cirscir;", HtmlEntityService.Convert(10690));
      HtmlEntityService.AddSingle(symbols, "clubs;", HtmlEntityService.Convert(9827));
      HtmlEntityService.AddSingle(symbols, "clubsuit;", HtmlEntityService.Convert(9827));
      HtmlEntityService.AddSingle(symbols, "colon;", HtmlEntityService.Convert(58));
      HtmlEntityService.AddSingle(symbols, "colone;", HtmlEntityService.Convert(8788));
      HtmlEntityService.AddSingle(symbols, "coloneq;", HtmlEntityService.Convert(8788));
      HtmlEntityService.AddSingle(symbols, "comma;", HtmlEntityService.Convert(44));
      HtmlEntityService.AddSingle(symbols, "commat;", HtmlEntityService.Convert(64));
      HtmlEntityService.AddSingle(symbols, "comp;", HtmlEntityService.Convert(8705));
      HtmlEntityService.AddSingle(symbols, "compfn;", HtmlEntityService.Convert(8728));
      HtmlEntityService.AddSingle(symbols, "complement;", HtmlEntityService.Convert(8705));
      HtmlEntityService.AddSingle(symbols, "complexes;", HtmlEntityService.Convert(8450));
      HtmlEntityService.AddSingle(symbols, "cong;", HtmlEntityService.Convert(8773));
      HtmlEntityService.AddSingle(symbols, "congdot;", HtmlEntityService.Convert(10861));
      HtmlEntityService.AddSingle(symbols, "conint;", HtmlEntityService.Convert(8750));
      HtmlEntityService.AddSingle(symbols, "copf;", HtmlEntityService.Convert(120148));
      HtmlEntityService.AddSingle(symbols, "coprod;", HtmlEntityService.Convert(8720));
      HtmlEntityService.AddBoth(symbols, "copy;", HtmlEntityService.Convert(169));
      HtmlEntityService.AddSingle(symbols, "copysr;", HtmlEntityService.Convert(8471));
      HtmlEntityService.AddSingle(symbols, "crarr;", HtmlEntityService.Convert(8629));
      HtmlEntityService.AddSingle(symbols, "cross;", HtmlEntityService.Convert(10007));
      HtmlEntityService.AddSingle(symbols, "cscr;", HtmlEntityService.Convert(119992));
      HtmlEntityService.AddSingle(symbols, "csub;", HtmlEntityService.Convert(10959));
      HtmlEntityService.AddSingle(symbols, "csube;", HtmlEntityService.Convert(10961));
      HtmlEntityService.AddSingle(symbols, "csup;", HtmlEntityService.Convert(10960));
      HtmlEntityService.AddSingle(symbols, "csupe;", HtmlEntityService.Convert(10962));
      HtmlEntityService.AddSingle(symbols, "ctdot;", HtmlEntityService.Convert(8943));
      HtmlEntityService.AddSingle(symbols, "cudarrl;", HtmlEntityService.Convert(10552));
      HtmlEntityService.AddSingle(symbols, "cudarrr;", HtmlEntityService.Convert(10549));
      HtmlEntityService.AddSingle(symbols, "cuepr;", HtmlEntityService.Convert(8926));
      HtmlEntityService.AddSingle(symbols, "cuesc;", HtmlEntityService.Convert(8927));
      HtmlEntityService.AddSingle(symbols, "cularr;", HtmlEntityService.Convert(8630));
      HtmlEntityService.AddSingle(symbols, "cularrp;", HtmlEntityService.Convert(10557));
      HtmlEntityService.AddSingle(symbols, "cup;", HtmlEntityService.Convert(8746));
      HtmlEntityService.AddSingle(symbols, "cupbrcap;", HtmlEntityService.Convert(10824));
      HtmlEntityService.AddSingle(symbols, "cupcap;", HtmlEntityService.Convert(10822));
      HtmlEntityService.AddSingle(symbols, "cupcup;", HtmlEntityService.Convert(10826));
      HtmlEntityService.AddSingle(symbols, "cupdot;", HtmlEntityService.Convert(8845));
      HtmlEntityService.AddSingle(symbols, "cupor;", HtmlEntityService.Convert(10821));
      HtmlEntityService.AddSingle(symbols, "cups;", HtmlEntityService.Convert(8746, 65024));
      HtmlEntityService.AddSingle(symbols, "curarr;", HtmlEntityService.Convert(8631));
      HtmlEntityService.AddSingle(symbols, "curarrm;", HtmlEntityService.Convert(10556));
      HtmlEntityService.AddSingle(symbols, "curlyeqprec;", HtmlEntityService.Convert(8926));
      HtmlEntityService.AddSingle(symbols, "curlyeqsucc;", HtmlEntityService.Convert(8927));
      HtmlEntityService.AddSingle(symbols, "curlyvee;", HtmlEntityService.Convert(8910));
      HtmlEntityService.AddSingle(symbols, "curlywedge;", HtmlEntityService.Convert(8911));
      HtmlEntityService.AddBoth(symbols, "curren;", HtmlEntityService.Convert(164));
      HtmlEntityService.AddSingle(symbols, "curvearrowleft;", HtmlEntityService.Convert(8630));
      HtmlEntityService.AddSingle(symbols, "curvearrowright;", HtmlEntityService.Convert(8631));
      HtmlEntityService.AddSingle(symbols, "cuvee;", HtmlEntityService.Convert(8910));
      HtmlEntityService.AddSingle(symbols, "cuwed;", HtmlEntityService.Convert(8911));
      HtmlEntityService.AddSingle(symbols, "cwconint;", HtmlEntityService.Convert(8754));
      HtmlEntityService.AddSingle(symbols, "cwint;", HtmlEntityService.Convert(8753));
      HtmlEntityService.AddSingle(symbols, "cylcty;", HtmlEntityService.Convert(9005));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigC()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Cacute;", HtmlEntityService.Convert(262));
      HtmlEntityService.AddSingle(symbols, "Cap;", HtmlEntityService.Convert(8914));
      HtmlEntityService.AddSingle(symbols, "CapitalDifferentialD;", HtmlEntityService.Convert(8517));
      HtmlEntityService.AddSingle(symbols, "Cayleys;", HtmlEntityService.Convert(8493));
      HtmlEntityService.AddSingle(symbols, "Ccaron;", HtmlEntityService.Convert(268));
      HtmlEntityService.AddBoth(symbols, "Ccedil;", HtmlEntityService.Convert(199));
      HtmlEntityService.AddSingle(symbols, "Ccirc;", HtmlEntityService.Convert(264));
      HtmlEntityService.AddSingle(symbols, "Cconint;", HtmlEntityService.Convert(8752));
      HtmlEntityService.AddSingle(symbols, "Cdot;", HtmlEntityService.Convert(266));
      HtmlEntityService.AddSingle(symbols, "Cedilla;", HtmlEntityService.Convert(184));
      HtmlEntityService.AddSingle(symbols, "CenterDot;", HtmlEntityService.Convert(183));
      HtmlEntityService.AddSingle(symbols, "Cfr;", HtmlEntityService.Convert(8493));
      HtmlEntityService.AddSingle(symbols, "CHcy;", HtmlEntityService.Convert(1063));
      HtmlEntityService.AddSingle(symbols, "Chi;", HtmlEntityService.Convert(935));
      HtmlEntityService.AddSingle(symbols, "CircleDot;", HtmlEntityService.Convert(8857));
      HtmlEntityService.AddSingle(symbols, "CircleMinus;", HtmlEntityService.Convert(8854));
      HtmlEntityService.AddSingle(symbols, "CirclePlus;", HtmlEntityService.Convert(8853));
      HtmlEntityService.AddSingle(symbols, "CircleTimes;", HtmlEntityService.Convert(8855));
      HtmlEntityService.AddSingle(symbols, "ClockwiseContourIntegral;", HtmlEntityService.Convert(8754));
      HtmlEntityService.AddSingle(symbols, "CloseCurlyDoubleQuote;", HtmlEntityService.Convert(8221));
      HtmlEntityService.AddSingle(symbols, "CloseCurlyQuote;", HtmlEntityService.Convert(8217));
      HtmlEntityService.AddSingle(symbols, "Colon;", HtmlEntityService.Convert(8759));
      HtmlEntityService.AddSingle(symbols, "Colone;", HtmlEntityService.Convert(10868));
      HtmlEntityService.AddSingle(symbols, "Congruent;", HtmlEntityService.Convert(8801));
      HtmlEntityService.AddSingle(symbols, "Conint;", HtmlEntityService.Convert(8751));
      HtmlEntityService.AddSingle(symbols, "ContourIntegral;", HtmlEntityService.Convert(8750));
      HtmlEntityService.AddSingle(symbols, "Copf;", HtmlEntityService.Convert(8450));
      HtmlEntityService.AddSingle(symbols, "Coproduct;", HtmlEntityService.Convert(8720));
      HtmlEntityService.AddBoth(symbols, "COPY;", HtmlEntityService.Convert(169));
      HtmlEntityService.AddSingle(symbols, "CounterClockwiseContourIntegral;", HtmlEntityService.Convert(8755));
      HtmlEntityService.AddSingle(symbols, "Cross;", HtmlEntityService.Convert(10799));
      HtmlEntityService.AddSingle(symbols, "Cscr;", HtmlEntityService.Convert(119966));
      HtmlEntityService.AddSingle(symbols, "Cup;", HtmlEntityService.Convert(8915));
      HtmlEntityService.AddSingle(symbols, "CupCap;", HtmlEntityService.Convert(8781));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleD()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "dagger;", HtmlEntityService.Convert(8224));
      HtmlEntityService.AddSingle(symbols, "daleth;", HtmlEntityService.Convert(8504));
      HtmlEntityService.AddSingle(symbols, "dArr;", HtmlEntityService.Convert(8659));
      HtmlEntityService.AddSingle(symbols, "darr;", HtmlEntityService.Convert(8595));
      HtmlEntityService.AddSingle(symbols, "dash;", HtmlEntityService.Convert(8208));
      HtmlEntityService.AddSingle(symbols, "dashv;", HtmlEntityService.Convert(8867));
      HtmlEntityService.AddSingle(symbols, "dbkarow;", HtmlEntityService.Convert(10511));
      HtmlEntityService.AddSingle(symbols, "dblac;", HtmlEntityService.Convert(733));
      HtmlEntityService.AddSingle(symbols, "dcaron;", HtmlEntityService.Convert(271));
      HtmlEntityService.AddSingle(symbols, "dcy;", HtmlEntityService.Convert(1076));
      HtmlEntityService.AddSingle(symbols, "dd;", HtmlEntityService.Convert(8518));
      HtmlEntityService.AddSingle(symbols, "ddagger;", HtmlEntityService.Convert(8225));
      HtmlEntityService.AddSingle(symbols, "ddarr;", HtmlEntityService.Convert(8650));
      HtmlEntityService.AddSingle(symbols, "ddotseq;", HtmlEntityService.Convert(10871));
      HtmlEntityService.AddBoth(symbols, "deg;", HtmlEntityService.Convert(176));
      HtmlEntityService.AddSingle(symbols, "delta;", HtmlEntityService.Convert(948));
      HtmlEntityService.AddSingle(symbols, "demptyv;", HtmlEntityService.Convert(10673));
      HtmlEntityService.AddSingle(symbols, "dfisht;", HtmlEntityService.Convert(10623));
      HtmlEntityService.AddSingle(symbols, "dfr;", HtmlEntityService.Convert(120097));
      HtmlEntityService.AddSingle(symbols, "dHar;", HtmlEntityService.Convert(10597));
      HtmlEntityService.AddSingle(symbols, "dharl;", HtmlEntityService.Convert(8643));
      HtmlEntityService.AddSingle(symbols, "dharr;", HtmlEntityService.Convert(8642));
      HtmlEntityService.AddSingle(symbols, "diam;", HtmlEntityService.Convert(8900));
      HtmlEntityService.AddSingle(symbols, "diamond;", HtmlEntityService.Convert(8900));
      HtmlEntityService.AddSingle(symbols, "diamondsuit;", HtmlEntityService.Convert(9830));
      HtmlEntityService.AddSingle(symbols, "diams;", HtmlEntityService.Convert(9830));
      HtmlEntityService.AddSingle(symbols, "die;", HtmlEntityService.Convert(168));
      HtmlEntityService.AddSingle(symbols, "digamma;", HtmlEntityService.Convert(989));
      HtmlEntityService.AddSingle(symbols, "disin;", HtmlEntityService.Convert(8946));
      HtmlEntityService.AddSingle(symbols, "div;", HtmlEntityService.Convert(247));
      HtmlEntityService.AddBoth(symbols, "divide;", HtmlEntityService.Convert(247));
      HtmlEntityService.AddSingle(symbols, "divideontimes;", HtmlEntityService.Convert(8903));
      HtmlEntityService.AddSingle(symbols, "divonx;", HtmlEntityService.Convert(8903));
      HtmlEntityService.AddSingle(symbols, "djcy;", HtmlEntityService.Convert(1106));
      HtmlEntityService.AddSingle(symbols, "dlcorn;", HtmlEntityService.Convert(8990));
      HtmlEntityService.AddSingle(symbols, "dlcrop;", HtmlEntityService.Convert(8973));
      HtmlEntityService.AddSingle(symbols, "dollar;", HtmlEntityService.Convert(36));
      HtmlEntityService.AddSingle(symbols, "dopf;", HtmlEntityService.Convert(120149));
      HtmlEntityService.AddSingle(symbols, "dot;", HtmlEntityService.Convert(729));
      HtmlEntityService.AddSingle(symbols, "doteq;", HtmlEntityService.Convert(8784));
      HtmlEntityService.AddSingle(symbols, "doteqdot;", HtmlEntityService.Convert(8785));
      HtmlEntityService.AddSingle(symbols, "dotminus;", HtmlEntityService.Convert(8760));
      HtmlEntityService.AddSingle(symbols, "dotplus;", HtmlEntityService.Convert(8724));
      HtmlEntityService.AddSingle(symbols, "dotsquare;", HtmlEntityService.Convert(8865));
      HtmlEntityService.AddSingle(symbols, "doublebarwedge;", HtmlEntityService.Convert(8966));
      HtmlEntityService.AddSingle(symbols, "downarrow;", HtmlEntityService.Convert(8595));
      HtmlEntityService.AddSingle(symbols, "downdownarrows;", HtmlEntityService.Convert(8650));
      HtmlEntityService.AddSingle(symbols, "downharpoonleft;", HtmlEntityService.Convert(8643));
      HtmlEntityService.AddSingle(symbols, "downharpoonright;", HtmlEntityService.Convert(8642));
      HtmlEntityService.AddSingle(symbols, "drbkarow;", HtmlEntityService.Convert(10512));
      HtmlEntityService.AddSingle(symbols, "drcorn;", HtmlEntityService.Convert(8991));
      HtmlEntityService.AddSingle(symbols, "drcrop;", HtmlEntityService.Convert(8972));
      HtmlEntityService.AddSingle(symbols, "dscr;", HtmlEntityService.Convert(119993));
      HtmlEntityService.AddSingle(symbols, "dscy;", HtmlEntityService.Convert(1109));
      HtmlEntityService.AddSingle(symbols, "dsol;", HtmlEntityService.Convert(10742));
      HtmlEntityService.AddSingle(symbols, "dstrok;", HtmlEntityService.Convert(273));
      HtmlEntityService.AddSingle(symbols, "dtdot;", HtmlEntityService.Convert(8945));
      HtmlEntityService.AddSingle(symbols, "dtri;", HtmlEntityService.Convert(9663));
      HtmlEntityService.AddSingle(symbols, "dtrif;", HtmlEntityService.Convert(9662));
      HtmlEntityService.AddSingle(symbols, "duarr;", HtmlEntityService.Convert(8693));
      HtmlEntityService.AddSingle(symbols, "duhar;", HtmlEntityService.Convert(10607));
      HtmlEntityService.AddSingle(symbols, "dwangle;", HtmlEntityService.Convert(10662));
      HtmlEntityService.AddSingle(symbols, "dzcy;", HtmlEntityService.Convert(1119));
      HtmlEntityService.AddSingle(symbols, "dzigrarr;", HtmlEntityService.Convert(10239));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigD()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Dagger;", HtmlEntityService.Convert(8225));
      HtmlEntityService.AddSingle(symbols, "Darr;", HtmlEntityService.Convert(8609));
      HtmlEntityService.AddSingle(symbols, "Dashv;", HtmlEntityService.Convert(10980));
      HtmlEntityService.AddSingle(symbols, "Dcaron;", HtmlEntityService.Convert(270));
      HtmlEntityService.AddSingle(symbols, "Dcy;", HtmlEntityService.Convert(1044));
      HtmlEntityService.AddSingle(symbols, "DD;", HtmlEntityService.Convert(8517));
      HtmlEntityService.AddSingle(symbols, "DDotrahd;", HtmlEntityService.Convert(10513));
      HtmlEntityService.AddSingle(symbols, "Del;", HtmlEntityService.Convert(8711));
      HtmlEntityService.AddSingle(symbols, "Delta;", HtmlEntityService.Convert(916));
      HtmlEntityService.AddSingle(symbols, "Dfr;", HtmlEntityService.Convert(120071));
      HtmlEntityService.AddSingle(symbols, "DiacriticalAcute;", HtmlEntityService.Convert(180));
      HtmlEntityService.AddSingle(symbols, "DiacriticalDot;", HtmlEntityService.Convert(729));
      HtmlEntityService.AddSingle(symbols, "DiacriticalDoubleAcute;", HtmlEntityService.Convert(733));
      HtmlEntityService.AddSingle(symbols, "DiacriticalGrave;", HtmlEntityService.Convert(96));
      HtmlEntityService.AddSingle(symbols, "DiacriticalTilde;", HtmlEntityService.Convert(732));
      HtmlEntityService.AddSingle(symbols, "Diamond;", HtmlEntityService.Convert(8900));
      HtmlEntityService.AddSingle(symbols, "DifferentialD;", HtmlEntityService.Convert(8518));
      HtmlEntityService.AddSingle(symbols, "DJcy;", HtmlEntityService.Convert(1026));
      HtmlEntityService.AddSingle(symbols, "Dopf;", HtmlEntityService.Convert(120123));
      HtmlEntityService.AddSingle(symbols, "Dot;", HtmlEntityService.Convert(168));
      HtmlEntityService.AddSingle(symbols, "DotDot;", HtmlEntityService.Convert(8412));
      HtmlEntityService.AddSingle(symbols, "DotEqual;", HtmlEntityService.Convert(8784));
      HtmlEntityService.AddSingle(symbols, "DoubleContourIntegral;", HtmlEntityService.Convert(8751));
      HtmlEntityService.AddSingle(symbols, "DoubleDot;", HtmlEntityService.Convert(168));
      HtmlEntityService.AddSingle(symbols, "DoubleDownArrow;", HtmlEntityService.Convert(8659));
      HtmlEntityService.AddSingle(symbols, "DoubleLeftArrow;", HtmlEntityService.Convert(8656));
      HtmlEntityService.AddSingle(symbols, "DoubleLeftRightArrow;", HtmlEntityService.Convert(8660));
      HtmlEntityService.AddSingle(symbols, "DoubleLeftTee;", HtmlEntityService.Convert(10980));
      HtmlEntityService.AddSingle(symbols, "DoubleLongLeftArrow;", HtmlEntityService.Convert(10232));
      HtmlEntityService.AddSingle(symbols, "DoubleLongLeftRightArrow;", HtmlEntityService.Convert(10234));
      HtmlEntityService.AddSingle(symbols, "DoubleLongRightArrow;", HtmlEntityService.Convert(10233));
      HtmlEntityService.AddSingle(symbols, "DoubleRightArrow;", HtmlEntityService.Convert(8658));
      HtmlEntityService.AddSingle(symbols, "DoubleRightTee;", HtmlEntityService.Convert(8872));
      HtmlEntityService.AddSingle(symbols, "DoubleUpArrow;", HtmlEntityService.Convert(8657));
      HtmlEntityService.AddSingle(symbols, "DoubleUpDownArrow;", HtmlEntityService.Convert(8661));
      HtmlEntityService.AddSingle(symbols, "DoubleVerticalBar;", HtmlEntityService.Convert(8741));
      HtmlEntityService.AddSingle(symbols, "DownArrow;", HtmlEntityService.Convert(8595));
      HtmlEntityService.AddSingle(symbols, "Downarrow;", HtmlEntityService.Convert(8659));
      HtmlEntityService.AddSingle(symbols, "DownArrowBar;", HtmlEntityService.Convert(10515));
      HtmlEntityService.AddSingle(symbols, "DownArrowUpArrow;", HtmlEntityService.Convert(8693));
      HtmlEntityService.AddSingle(symbols, "DownBreve;", HtmlEntityService.Convert(785));
      HtmlEntityService.AddSingle(symbols, "DownLeftRightVector;", HtmlEntityService.Convert(10576));
      HtmlEntityService.AddSingle(symbols, "DownLeftTeeVector;", HtmlEntityService.Convert(10590));
      HtmlEntityService.AddSingle(symbols, "DownLeftVector;", HtmlEntityService.Convert(8637));
      HtmlEntityService.AddSingle(symbols, "DownLeftVectorBar;", HtmlEntityService.Convert(10582));
      HtmlEntityService.AddSingle(symbols, "DownRightTeeVector;", HtmlEntityService.Convert(10591));
      HtmlEntityService.AddSingle(symbols, "DownRightVector;", HtmlEntityService.Convert(8641));
      HtmlEntityService.AddSingle(symbols, "DownRightVectorBar;", HtmlEntityService.Convert(10583));
      HtmlEntityService.AddSingle(symbols, "DownTee;", HtmlEntityService.Convert(8868));
      HtmlEntityService.AddSingle(symbols, "DownTeeArrow;", HtmlEntityService.Convert(8615));
      HtmlEntityService.AddSingle(symbols, "Dscr;", HtmlEntityService.Convert(119967));
      HtmlEntityService.AddSingle(symbols, "DScy;", HtmlEntityService.Convert(1029));
      HtmlEntityService.AddSingle(symbols, "Dstrok;", HtmlEntityService.Convert(272));
      HtmlEntityService.AddSingle(symbols, "DZcy;", HtmlEntityService.Convert(1039));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleE()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddBoth(symbols, "eacute;", HtmlEntityService.Convert(233));
      HtmlEntityService.AddSingle(symbols, "easter;", HtmlEntityService.Convert(10862));
      HtmlEntityService.AddSingle(symbols, "ecaron;", HtmlEntityService.Convert(283));
      HtmlEntityService.AddSingle(symbols, "ecir;", HtmlEntityService.Convert(8790));
      HtmlEntityService.AddBoth(symbols, "ecirc;", HtmlEntityService.Convert(234));
      HtmlEntityService.AddSingle(symbols, "ecolon;", HtmlEntityService.Convert(8789));
      HtmlEntityService.AddSingle(symbols, "ecy;", HtmlEntityService.Convert(1101));
      HtmlEntityService.AddSingle(symbols, "eDDot;", HtmlEntityService.Convert(10871));
      HtmlEntityService.AddSingle(symbols, "eDot;", HtmlEntityService.Convert(8785));
      HtmlEntityService.AddSingle(symbols, "edot;", HtmlEntityService.Convert(279));
      HtmlEntityService.AddSingle(symbols, "ee;", HtmlEntityService.Convert(8519));
      HtmlEntityService.AddSingle(symbols, "efDot;", HtmlEntityService.Convert(8786));
      HtmlEntityService.AddSingle(symbols, "efr;", HtmlEntityService.Convert(120098));
      HtmlEntityService.AddSingle(symbols, "eg;", HtmlEntityService.Convert(10906));
      HtmlEntityService.AddBoth(symbols, "egrave;", HtmlEntityService.Convert(232));
      HtmlEntityService.AddSingle(symbols, "egs;", HtmlEntityService.Convert(10902));
      HtmlEntityService.AddSingle(symbols, "egsdot;", HtmlEntityService.Convert(10904));
      HtmlEntityService.AddSingle(symbols, "el;", HtmlEntityService.Convert(10905));
      HtmlEntityService.AddSingle(symbols, "elinters;", HtmlEntityService.Convert(9191));
      HtmlEntityService.AddSingle(symbols, "ell;", HtmlEntityService.Convert(8467));
      HtmlEntityService.AddSingle(symbols, "els;", HtmlEntityService.Convert(10901));
      HtmlEntityService.AddSingle(symbols, "elsdot;", HtmlEntityService.Convert(10903));
      HtmlEntityService.AddSingle(symbols, "emacr;", HtmlEntityService.Convert(275));
      HtmlEntityService.AddSingle(symbols, "empty;", HtmlEntityService.Convert(8709));
      HtmlEntityService.AddSingle(symbols, "emptyset;", HtmlEntityService.Convert(8709));
      HtmlEntityService.AddSingle(symbols, "emptyv;", HtmlEntityService.Convert(8709));
      HtmlEntityService.AddSingle(symbols, "emsp;", HtmlEntityService.Convert(8195));
      HtmlEntityService.AddSingle(symbols, "emsp13;", HtmlEntityService.Convert(8196));
      HtmlEntityService.AddSingle(symbols, "emsp14;", HtmlEntityService.Convert(8197));
      HtmlEntityService.AddSingle(symbols, "eng;", HtmlEntityService.Convert(331));
      HtmlEntityService.AddSingle(symbols, "ensp;", HtmlEntityService.Convert(8194));
      HtmlEntityService.AddSingle(symbols, "eogon;", HtmlEntityService.Convert(281));
      HtmlEntityService.AddSingle(symbols, "eopf;", HtmlEntityService.Convert(120150));
      HtmlEntityService.AddSingle(symbols, "epar;", HtmlEntityService.Convert(8917));
      HtmlEntityService.AddSingle(symbols, "eparsl;", HtmlEntityService.Convert(10723));
      HtmlEntityService.AddSingle(symbols, "eplus;", HtmlEntityService.Convert(10865));
      HtmlEntityService.AddSingle(symbols, "epsi;", HtmlEntityService.Convert(949));
      HtmlEntityService.AddSingle(symbols, "epsilon;", HtmlEntityService.Convert(949));
      HtmlEntityService.AddSingle(symbols, "epsiv;", HtmlEntityService.Convert(1013));
      HtmlEntityService.AddSingle(symbols, "eqcirc;", HtmlEntityService.Convert(8790));
      HtmlEntityService.AddSingle(symbols, "eqcolon;", HtmlEntityService.Convert(8789));
      HtmlEntityService.AddSingle(symbols, "eqsim;", HtmlEntityService.Convert(8770));
      HtmlEntityService.AddSingle(symbols, "eqslantgtr;", HtmlEntityService.Convert(10902));
      HtmlEntityService.AddSingle(symbols, "eqslantless;", HtmlEntityService.Convert(10901));
      HtmlEntityService.AddSingle(symbols, "equals;", HtmlEntityService.Convert(61));
      HtmlEntityService.AddSingle(symbols, "equest;", HtmlEntityService.Convert(8799));
      HtmlEntityService.AddSingle(symbols, "equiv;", HtmlEntityService.Convert(8801));
      HtmlEntityService.AddSingle(symbols, "equivDD;", HtmlEntityService.Convert(10872));
      HtmlEntityService.AddSingle(symbols, "eqvparsl;", HtmlEntityService.Convert(10725));
      HtmlEntityService.AddSingle(symbols, "erarr;", HtmlEntityService.Convert(10609));
      HtmlEntityService.AddSingle(symbols, "erDot;", HtmlEntityService.Convert(8787));
      HtmlEntityService.AddSingle(symbols, "escr;", HtmlEntityService.Convert(8495));
      HtmlEntityService.AddSingle(symbols, "esdot;", HtmlEntityService.Convert(8784));
      HtmlEntityService.AddSingle(symbols, "esim;", HtmlEntityService.Convert(8770));
      HtmlEntityService.AddSingle(symbols, "eta;", HtmlEntityService.Convert(951));
      HtmlEntityService.AddBoth(symbols, "eth;", HtmlEntityService.Convert(240));
      HtmlEntityService.AddBoth(symbols, "euml;", HtmlEntityService.Convert(235));
      HtmlEntityService.AddSingle(symbols, "euro;", HtmlEntityService.Convert(8364));
      HtmlEntityService.AddSingle(symbols, "excl;", HtmlEntityService.Convert(33));
      HtmlEntityService.AddSingle(symbols, "exist;", HtmlEntityService.Convert(8707));
      HtmlEntityService.AddSingle(symbols, "expectation;", HtmlEntityService.Convert(8496));
      HtmlEntityService.AddSingle(symbols, "exponentiale;", HtmlEntityService.Convert(8519));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigE()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddBoth(symbols, "Eacute;", HtmlEntityService.Convert(201));
      HtmlEntityService.AddSingle(symbols, "Ecaron;", HtmlEntityService.Convert(282));
      HtmlEntityService.AddBoth(symbols, "Ecirc;", HtmlEntityService.Convert(202));
      HtmlEntityService.AddSingle(symbols, "Ecy;", HtmlEntityService.Convert(1069));
      HtmlEntityService.AddSingle(symbols, "Edot;", HtmlEntityService.Convert(278));
      HtmlEntityService.AddSingle(symbols, "Efr;", HtmlEntityService.Convert(120072));
      HtmlEntityService.AddBoth(symbols, "Egrave;", HtmlEntityService.Convert(200));
      HtmlEntityService.AddSingle(symbols, "Element;", HtmlEntityService.Convert(8712));
      HtmlEntityService.AddSingle(symbols, "Emacr;", HtmlEntityService.Convert(274));
      HtmlEntityService.AddSingle(symbols, "EmptySmallSquare;", HtmlEntityService.Convert(9723));
      HtmlEntityService.AddSingle(symbols, "EmptyVerySmallSquare;", HtmlEntityService.Convert(9643));
      HtmlEntityService.AddSingle(symbols, "ENG;", HtmlEntityService.Convert(330));
      HtmlEntityService.AddSingle(symbols, "Eogon;", HtmlEntityService.Convert(280));
      HtmlEntityService.AddSingle(symbols, "Eopf;", HtmlEntityService.Convert(120124));
      HtmlEntityService.AddSingle(symbols, "Epsilon;", HtmlEntityService.Convert(917));
      HtmlEntityService.AddSingle(symbols, "Equal;", HtmlEntityService.Convert(10869));
      HtmlEntityService.AddSingle(symbols, "EqualTilde;", HtmlEntityService.Convert(8770));
      HtmlEntityService.AddSingle(symbols, "Equilibrium;", HtmlEntityService.Convert(8652));
      HtmlEntityService.AddSingle(symbols, "Escr;", HtmlEntityService.Convert(8496));
      HtmlEntityService.AddSingle(symbols, "Esim;", HtmlEntityService.Convert(10867));
      HtmlEntityService.AddSingle(symbols, "Eta;", HtmlEntityService.Convert(919));
      HtmlEntityService.AddBoth(symbols, "ETH;", HtmlEntityService.Convert(208));
      HtmlEntityService.AddBoth(symbols, "Euml;", HtmlEntityService.Convert(203));
      HtmlEntityService.AddSingle(symbols, "Exists;", HtmlEntityService.Convert(8707));
      HtmlEntityService.AddSingle(symbols, "ExponentialE;", HtmlEntityService.Convert(8519));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleF()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "fallingdotseq;", HtmlEntityService.Convert(8786));
      HtmlEntityService.AddSingle(symbols, "fcy;", HtmlEntityService.Convert(1092));
      HtmlEntityService.AddSingle(symbols, "female;", HtmlEntityService.Convert(9792));
      HtmlEntityService.AddSingle(symbols, "ffilig;", HtmlEntityService.Convert(64259));
      HtmlEntityService.AddSingle(symbols, "fflig;", HtmlEntityService.Convert(64256));
      HtmlEntityService.AddSingle(symbols, "ffllig;", HtmlEntityService.Convert(64260));
      HtmlEntityService.AddSingle(symbols, "ffr;", HtmlEntityService.Convert(120099));
      HtmlEntityService.AddSingle(symbols, "filig;", HtmlEntityService.Convert(64257));
      HtmlEntityService.AddSingle(symbols, "fjlig;", HtmlEntityService.Convert(102, 106));
      HtmlEntityService.AddSingle(symbols, "flat;", HtmlEntityService.Convert(9837));
      HtmlEntityService.AddSingle(symbols, "fllig;", HtmlEntityService.Convert(64258));
      HtmlEntityService.AddSingle(symbols, "fltns;", HtmlEntityService.Convert(9649));
      HtmlEntityService.AddSingle(symbols, "fnof;", HtmlEntityService.Convert(402));
      HtmlEntityService.AddSingle(symbols, "fopf;", HtmlEntityService.Convert(120151));
      HtmlEntityService.AddSingle(symbols, "forall;", HtmlEntityService.Convert(8704));
      HtmlEntityService.AddSingle(symbols, "fork;", HtmlEntityService.Convert(8916));
      HtmlEntityService.AddSingle(symbols, "forkv;", HtmlEntityService.Convert(10969));
      HtmlEntityService.AddSingle(symbols, "fpartint;", HtmlEntityService.Convert(10765));
      HtmlEntityService.AddBoth(symbols, "frac12;", HtmlEntityService.Convert(189));
      HtmlEntityService.AddSingle(symbols, "frac13;", HtmlEntityService.Convert(8531));
      HtmlEntityService.AddBoth(symbols, "frac14;", HtmlEntityService.Convert(188));
      HtmlEntityService.AddSingle(symbols, "frac15;", HtmlEntityService.Convert(8533));
      HtmlEntityService.AddSingle(symbols, "frac16;", HtmlEntityService.Convert(8537));
      HtmlEntityService.AddSingle(symbols, "frac18;", HtmlEntityService.Convert(8539));
      HtmlEntityService.AddSingle(symbols, "frac23;", HtmlEntityService.Convert(8532));
      HtmlEntityService.AddSingle(symbols, "frac25;", HtmlEntityService.Convert(8534));
      HtmlEntityService.AddBoth(symbols, "frac34;", HtmlEntityService.Convert(190));
      HtmlEntityService.AddSingle(symbols, "frac35;", HtmlEntityService.Convert(8535));
      HtmlEntityService.AddSingle(symbols, "frac38;", HtmlEntityService.Convert(8540));
      HtmlEntityService.AddSingle(symbols, "frac45;", HtmlEntityService.Convert(8536));
      HtmlEntityService.AddSingle(symbols, "frac56;", HtmlEntityService.Convert(8538));
      HtmlEntityService.AddSingle(symbols, "frac58;", HtmlEntityService.Convert(8541));
      HtmlEntityService.AddSingle(symbols, "frac78;", HtmlEntityService.Convert(8542));
      HtmlEntityService.AddSingle(symbols, "frasl;", HtmlEntityService.Convert(8260));
      HtmlEntityService.AddSingle(symbols, "frown;", HtmlEntityService.Convert(8994));
      HtmlEntityService.AddSingle(symbols, "fscr;", HtmlEntityService.Convert(119995));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigF()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Fcy;", HtmlEntityService.Convert(1060));
      HtmlEntityService.AddSingle(symbols, "Ffr;", HtmlEntityService.Convert(120073));
      HtmlEntityService.AddSingle(symbols, "FilledSmallSquare;", HtmlEntityService.Convert(9724));
      HtmlEntityService.AddSingle(symbols, "FilledVerySmallSquare;", HtmlEntityService.Convert(9642));
      HtmlEntityService.AddSingle(symbols, "Fopf;", HtmlEntityService.Convert(120125));
      HtmlEntityService.AddSingle(symbols, "ForAll;", HtmlEntityService.Convert(8704));
      HtmlEntityService.AddSingle(symbols, "Fouriertrf;", HtmlEntityService.Convert(8497));
      HtmlEntityService.AddSingle(symbols, "Fscr;", HtmlEntityService.Convert(8497));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleG()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "gacute;", HtmlEntityService.Convert(501));
      HtmlEntityService.AddSingle(symbols, "gamma;", HtmlEntityService.Convert(947));
      HtmlEntityService.AddSingle(symbols, "gammad;", HtmlEntityService.Convert(989));
      HtmlEntityService.AddSingle(symbols, "gap;", HtmlEntityService.Convert(10886));
      HtmlEntityService.AddSingle(symbols, "gbreve;", HtmlEntityService.Convert(287));
      HtmlEntityService.AddSingle(symbols, "gcirc;", HtmlEntityService.Convert(285));
      HtmlEntityService.AddSingle(symbols, "gcy;", HtmlEntityService.Convert(1075));
      HtmlEntityService.AddSingle(symbols, "gdot;", HtmlEntityService.Convert(289));
      HtmlEntityService.AddSingle(symbols, "gE;", HtmlEntityService.Convert(8807));
      HtmlEntityService.AddSingle(symbols, "ge;", HtmlEntityService.Convert(8805));
      HtmlEntityService.AddSingle(symbols, "gEl;", HtmlEntityService.Convert(10892));
      HtmlEntityService.AddSingle(symbols, "gel;", HtmlEntityService.Convert(8923));
      HtmlEntityService.AddSingle(symbols, "geq;", HtmlEntityService.Convert(8805));
      HtmlEntityService.AddSingle(symbols, "geqq;", HtmlEntityService.Convert(8807));
      HtmlEntityService.AddSingle(symbols, "geqslant;", HtmlEntityService.Convert(10878));
      HtmlEntityService.AddSingle(symbols, "ges;", HtmlEntityService.Convert(10878));
      HtmlEntityService.AddSingle(symbols, "gescc;", HtmlEntityService.Convert(10921));
      HtmlEntityService.AddSingle(symbols, "gesdot;", HtmlEntityService.Convert(10880));
      HtmlEntityService.AddSingle(symbols, "gesdoto;", HtmlEntityService.Convert(10882));
      HtmlEntityService.AddSingle(symbols, "gesdotol;", HtmlEntityService.Convert(10884));
      HtmlEntityService.AddSingle(symbols, "gesl;", HtmlEntityService.Convert(8923, 65024));
      HtmlEntityService.AddSingle(symbols, "gesles;", HtmlEntityService.Convert(10900));
      HtmlEntityService.AddSingle(symbols, "gfr;", HtmlEntityService.Convert(120100));
      HtmlEntityService.AddSingle(symbols, "gg;", HtmlEntityService.Convert(8811));
      HtmlEntityService.AddSingle(symbols, "ggg;", HtmlEntityService.Convert(8921));
      HtmlEntityService.AddSingle(symbols, "gimel;", HtmlEntityService.Convert(8503));
      HtmlEntityService.AddSingle(symbols, "gjcy;", HtmlEntityService.Convert(1107));
      HtmlEntityService.AddSingle(symbols, "gl;", HtmlEntityService.Convert(8823));
      HtmlEntityService.AddSingle(symbols, "gla;", HtmlEntityService.Convert(10917));
      HtmlEntityService.AddSingle(symbols, "glE;", HtmlEntityService.Convert(10898));
      HtmlEntityService.AddSingle(symbols, "glj;", HtmlEntityService.Convert(10916));
      HtmlEntityService.AddSingle(symbols, "gnap;", HtmlEntityService.Convert(10890));
      HtmlEntityService.AddSingle(symbols, "gnapprox;", HtmlEntityService.Convert(10890));
      HtmlEntityService.AddSingle(symbols, "gnE;", HtmlEntityService.Convert(8809));
      HtmlEntityService.AddSingle(symbols, "gne;", HtmlEntityService.Convert(10888));
      HtmlEntityService.AddSingle(symbols, "gneq;", HtmlEntityService.Convert(10888));
      HtmlEntityService.AddSingle(symbols, "gneqq;", HtmlEntityService.Convert(8809));
      HtmlEntityService.AddSingle(symbols, "gnsim;", HtmlEntityService.Convert(8935));
      HtmlEntityService.AddSingle(symbols, "gopf;", HtmlEntityService.Convert(120152));
      HtmlEntityService.AddSingle(symbols, "grave;", HtmlEntityService.Convert(96));
      HtmlEntityService.AddSingle(symbols, "gscr;", HtmlEntityService.Convert(8458));
      HtmlEntityService.AddSingle(symbols, "gsim;", HtmlEntityService.Convert(8819));
      HtmlEntityService.AddSingle(symbols, "gsime;", HtmlEntityService.Convert(10894));
      HtmlEntityService.AddSingle(symbols, "gsiml;", HtmlEntityService.Convert(10896));
      HtmlEntityService.AddBoth(symbols, "gt;", HtmlEntityService.Convert(62));
      HtmlEntityService.AddSingle(symbols, "gtcc;", HtmlEntityService.Convert(10919));
      HtmlEntityService.AddSingle(symbols, "gtcir;", HtmlEntityService.Convert(10874));
      HtmlEntityService.AddSingle(symbols, "gtdot;", HtmlEntityService.Convert(8919));
      HtmlEntityService.AddSingle(symbols, "gtlPar;", HtmlEntityService.Convert(10645));
      HtmlEntityService.AddSingle(symbols, "gtquest;", HtmlEntityService.Convert(10876));
      HtmlEntityService.AddSingle(symbols, "gtrapprox;", HtmlEntityService.Convert(10886));
      HtmlEntityService.AddSingle(symbols, "gtrarr;", HtmlEntityService.Convert(10616));
      HtmlEntityService.AddSingle(symbols, "gtrdot;", HtmlEntityService.Convert(8919));
      HtmlEntityService.AddSingle(symbols, "gtreqless;", HtmlEntityService.Convert(8923));
      HtmlEntityService.AddSingle(symbols, "gtreqqless;", HtmlEntityService.Convert(10892));
      HtmlEntityService.AddSingle(symbols, "gtrless;", HtmlEntityService.Convert(8823));
      HtmlEntityService.AddSingle(symbols, "gtrsim;", HtmlEntityService.Convert(8819));
      HtmlEntityService.AddSingle(symbols, "gvertneqq;", HtmlEntityService.Convert(8809, 65024));
      HtmlEntityService.AddSingle(symbols, "gvnE;", HtmlEntityService.Convert(8809, 65024));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigG()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Gamma;", HtmlEntityService.Convert(915));
      HtmlEntityService.AddSingle(symbols, "Gammad;", HtmlEntityService.Convert(988));
      HtmlEntityService.AddSingle(symbols, "Gbreve;", HtmlEntityService.Convert(286));
      HtmlEntityService.AddSingle(symbols, "Gcedil;", HtmlEntityService.Convert(290));
      HtmlEntityService.AddSingle(symbols, "Gcirc;", HtmlEntityService.Convert(284));
      HtmlEntityService.AddSingle(symbols, "Gcy;", HtmlEntityService.Convert(1043));
      HtmlEntityService.AddSingle(symbols, "Gdot;", HtmlEntityService.Convert(288));
      HtmlEntityService.AddSingle(symbols, "Gfr;", HtmlEntityService.Convert(120074));
      HtmlEntityService.AddSingle(symbols, "Gg;", HtmlEntityService.Convert(8921));
      HtmlEntityService.AddSingle(symbols, "GJcy;", HtmlEntityService.Convert(1027));
      HtmlEntityService.AddSingle(symbols, "Gopf;", HtmlEntityService.Convert(120126));
      HtmlEntityService.AddSingle(symbols, "GreaterEqual;", HtmlEntityService.Convert(8805));
      HtmlEntityService.AddSingle(symbols, "GreaterEqualLess;", HtmlEntityService.Convert(8923));
      HtmlEntityService.AddSingle(symbols, "GreaterFullEqual;", HtmlEntityService.Convert(8807));
      HtmlEntityService.AddSingle(symbols, "GreaterGreater;", HtmlEntityService.Convert(10914));
      HtmlEntityService.AddSingle(symbols, "GreaterLess;", HtmlEntityService.Convert(8823));
      HtmlEntityService.AddSingle(symbols, "GreaterSlantEqual;", HtmlEntityService.Convert(10878));
      HtmlEntityService.AddSingle(symbols, "GreaterTilde;", HtmlEntityService.Convert(8819));
      HtmlEntityService.AddSingle(symbols, "Gscr;", HtmlEntityService.Convert(119970));
      HtmlEntityService.AddBoth(symbols, "GT;", HtmlEntityService.Convert(62));
      HtmlEntityService.AddSingle(symbols, "Gt;", HtmlEntityService.Convert(8811));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleH()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "hairsp;", HtmlEntityService.Convert(8202));
      HtmlEntityService.AddSingle(symbols, "half;", HtmlEntityService.Convert(189));
      HtmlEntityService.AddSingle(symbols, "hamilt;", HtmlEntityService.Convert(8459));
      HtmlEntityService.AddSingle(symbols, "hardcy;", HtmlEntityService.Convert(1098));
      HtmlEntityService.AddSingle(symbols, "hArr;", HtmlEntityService.Convert(8660));
      HtmlEntityService.AddSingle(symbols, "harr;", HtmlEntityService.Convert(8596));
      HtmlEntityService.AddSingle(symbols, "harrcir;", HtmlEntityService.Convert(10568));
      HtmlEntityService.AddSingle(symbols, "harrw;", HtmlEntityService.Convert(8621));
      HtmlEntityService.AddSingle(symbols, "hbar;", HtmlEntityService.Convert(8463));
      HtmlEntityService.AddSingle(symbols, "hcirc;", HtmlEntityService.Convert(293));
      HtmlEntityService.AddSingle(symbols, "hearts;", HtmlEntityService.Convert(9829));
      HtmlEntityService.AddSingle(symbols, "heartsuit;", HtmlEntityService.Convert(9829));
      HtmlEntityService.AddSingle(symbols, "hellip;", HtmlEntityService.Convert(8230));
      HtmlEntityService.AddSingle(symbols, "hercon;", HtmlEntityService.Convert(8889));
      HtmlEntityService.AddSingle(symbols, "hfr;", HtmlEntityService.Convert(120101));
      HtmlEntityService.AddSingle(symbols, "hksearow;", HtmlEntityService.Convert(10533));
      HtmlEntityService.AddSingle(symbols, "hkswarow;", HtmlEntityService.Convert(10534));
      HtmlEntityService.AddSingle(symbols, "hoarr;", HtmlEntityService.Convert(8703));
      HtmlEntityService.AddSingle(symbols, "homtht;", HtmlEntityService.Convert(8763));
      HtmlEntityService.AddSingle(symbols, "hookleftarrow;", HtmlEntityService.Convert(8617));
      HtmlEntityService.AddSingle(symbols, "hookrightarrow;", HtmlEntityService.Convert(8618));
      HtmlEntityService.AddSingle(symbols, "hopf;", HtmlEntityService.Convert(120153));
      HtmlEntityService.AddSingle(symbols, "horbar;", HtmlEntityService.Convert(8213));
      HtmlEntityService.AddSingle(symbols, "hscr;", HtmlEntityService.Convert(119997));
      HtmlEntityService.AddSingle(symbols, "hslash;", HtmlEntityService.Convert(8463));
      HtmlEntityService.AddSingle(symbols, "hstrok;", HtmlEntityService.Convert(295));
      HtmlEntityService.AddSingle(symbols, "hybull;", HtmlEntityService.Convert(8259));
      HtmlEntityService.AddSingle(symbols, "hyphen;", HtmlEntityService.Convert(8208));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigH()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Hacek;", HtmlEntityService.Convert(711));
      HtmlEntityService.AddSingle(symbols, "HARDcy;", HtmlEntityService.Convert(1066));
      HtmlEntityService.AddSingle(symbols, "Hat;", HtmlEntityService.Convert(94));
      HtmlEntityService.AddSingle(symbols, "Hcirc;", HtmlEntityService.Convert(292));
      HtmlEntityService.AddSingle(symbols, "Hfr;", HtmlEntityService.Convert(8460));
      HtmlEntityService.AddSingle(symbols, "HilbertSpace;", HtmlEntityService.Convert(8459));
      HtmlEntityService.AddSingle(symbols, "Hopf;", HtmlEntityService.Convert(8461));
      HtmlEntityService.AddSingle(symbols, "HorizontalLine;", HtmlEntityService.Convert(9472));
      HtmlEntityService.AddSingle(symbols, "Hscr;", HtmlEntityService.Convert(8459));
      HtmlEntityService.AddSingle(symbols, "Hstrok;", HtmlEntityService.Convert(294));
      HtmlEntityService.AddSingle(symbols, "HumpDownHump;", HtmlEntityService.Convert(8782));
      HtmlEntityService.AddSingle(symbols, "HumpEqual;", HtmlEntityService.Convert(8783));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleI()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddBoth(symbols, "iacute;", HtmlEntityService.Convert(237));
      HtmlEntityService.AddSingle(symbols, "ic;", HtmlEntityService.Convert(8291));
      HtmlEntityService.AddBoth(symbols, "icirc;", HtmlEntityService.Convert(238));
      HtmlEntityService.AddSingle(symbols, "icy;", HtmlEntityService.Convert(1080));
      HtmlEntityService.AddSingle(symbols, "iecy;", HtmlEntityService.Convert(1077));
      HtmlEntityService.AddBoth(symbols, "iexcl;", HtmlEntityService.Convert(161));
      HtmlEntityService.AddSingle(symbols, "iff;", HtmlEntityService.Convert(8660));
      HtmlEntityService.AddSingle(symbols, "ifr;", HtmlEntityService.Convert(120102));
      HtmlEntityService.AddBoth(symbols, "igrave;", HtmlEntityService.Convert(236));
      HtmlEntityService.AddSingle(symbols, "ii;", HtmlEntityService.Convert(8520));
      HtmlEntityService.AddSingle(symbols, "iiiint;", HtmlEntityService.Convert(10764));
      HtmlEntityService.AddSingle(symbols, "iiint;", HtmlEntityService.Convert(8749));
      HtmlEntityService.AddSingle(symbols, "iinfin;", HtmlEntityService.Convert(10716));
      HtmlEntityService.AddSingle(symbols, "iiota;", HtmlEntityService.Convert(8489));
      HtmlEntityService.AddSingle(symbols, "ijlig;", HtmlEntityService.Convert(307));
      HtmlEntityService.AddSingle(symbols, "imacr;", HtmlEntityService.Convert(299));
      HtmlEntityService.AddSingle(symbols, "image;", HtmlEntityService.Convert(8465));
      HtmlEntityService.AddSingle(symbols, "imagline;", HtmlEntityService.Convert(8464));
      HtmlEntityService.AddSingle(symbols, "imagpart;", HtmlEntityService.Convert(8465));
      HtmlEntityService.AddSingle(symbols, "imath;", HtmlEntityService.Convert(305));
      HtmlEntityService.AddSingle(symbols, "imof;", HtmlEntityService.Convert(8887));
      HtmlEntityService.AddSingle(symbols, "imped;", HtmlEntityService.Convert(437));
      HtmlEntityService.AddSingle(symbols, "in;", HtmlEntityService.Convert(8712));
      HtmlEntityService.AddSingle(symbols, "incare;", HtmlEntityService.Convert(8453));
      HtmlEntityService.AddSingle(symbols, "infin;", HtmlEntityService.Convert(8734));
      HtmlEntityService.AddSingle(symbols, "infintie;", HtmlEntityService.Convert(10717));
      HtmlEntityService.AddSingle(symbols, "inodot;", HtmlEntityService.Convert(305));
      HtmlEntityService.AddSingle(symbols, "int;", HtmlEntityService.Convert(8747));
      HtmlEntityService.AddSingle(symbols, "intcal;", HtmlEntityService.Convert(8890));
      HtmlEntityService.AddSingle(symbols, "integers;", HtmlEntityService.Convert(8484));
      HtmlEntityService.AddSingle(symbols, "intercal;", HtmlEntityService.Convert(8890));
      HtmlEntityService.AddSingle(symbols, "intlarhk;", HtmlEntityService.Convert(10775));
      HtmlEntityService.AddSingle(symbols, "intprod;", HtmlEntityService.Convert(10812));
      HtmlEntityService.AddSingle(symbols, "iocy;", HtmlEntityService.Convert(1105));
      HtmlEntityService.AddSingle(symbols, "iogon;", HtmlEntityService.Convert(303));
      HtmlEntityService.AddSingle(symbols, "iopf;", HtmlEntityService.Convert(120154));
      HtmlEntityService.AddSingle(symbols, "iota;", HtmlEntityService.Convert(953));
      HtmlEntityService.AddSingle(symbols, "iprod;", HtmlEntityService.Convert(10812));
      HtmlEntityService.AddBoth(symbols, "iquest;", HtmlEntityService.Convert(191));
      HtmlEntityService.AddSingle(symbols, "iscr;", HtmlEntityService.Convert(119998));
      HtmlEntityService.AddSingle(symbols, "isin;", HtmlEntityService.Convert(8712));
      HtmlEntityService.AddSingle(symbols, "isindot;", HtmlEntityService.Convert(8949));
      HtmlEntityService.AddSingle(symbols, "isinE;", HtmlEntityService.Convert(8953));
      HtmlEntityService.AddSingle(symbols, "isins;", HtmlEntityService.Convert(8948));
      HtmlEntityService.AddSingle(symbols, "isinsv;", HtmlEntityService.Convert(8947));
      HtmlEntityService.AddSingle(symbols, "isinv;", HtmlEntityService.Convert(8712));
      HtmlEntityService.AddSingle(symbols, "it;", HtmlEntityService.Convert(8290));
      HtmlEntityService.AddSingle(symbols, "itilde;", HtmlEntityService.Convert(297));
      HtmlEntityService.AddSingle(symbols, "iukcy;", HtmlEntityService.Convert(1110));
      HtmlEntityService.AddBoth(symbols, "iuml;", HtmlEntityService.Convert(239));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigI()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddBoth(symbols, "Iacute;", HtmlEntityService.Convert(205));
      HtmlEntityService.AddBoth(symbols, "Icirc;", HtmlEntityService.Convert(206));
      HtmlEntityService.AddSingle(symbols, "Icy;", HtmlEntityService.Convert(1048));
      HtmlEntityService.AddSingle(symbols, "Idot;", HtmlEntityService.Convert(304));
      HtmlEntityService.AddSingle(symbols, "IEcy;", HtmlEntityService.Convert(1045));
      HtmlEntityService.AddSingle(symbols, "Ifr;", HtmlEntityService.Convert(8465));
      HtmlEntityService.AddBoth(symbols, "Igrave;", HtmlEntityService.Convert(204));
      HtmlEntityService.AddSingle(symbols, "IJlig;", HtmlEntityService.Convert(306));
      HtmlEntityService.AddSingle(symbols, "Im;", HtmlEntityService.Convert(8465));
      HtmlEntityService.AddSingle(symbols, "Imacr;", HtmlEntityService.Convert(298));
      HtmlEntityService.AddSingle(symbols, "ImaginaryI;", HtmlEntityService.Convert(8520));
      HtmlEntityService.AddSingle(symbols, "Implies;", HtmlEntityService.Convert(8658));
      HtmlEntityService.AddSingle(symbols, "Int;", HtmlEntityService.Convert(8748));
      HtmlEntityService.AddSingle(symbols, "Integral;", HtmlEntityService.Convert(8747));
      HtmlEntityService.AddSingle(symbols, "Intersection;", HtmlEntityService.Convert(8898));
      HtmlEntityService.AddSingle(symbols, "InvisibleComma;", HtmlEntityService.Convert(8291));
      HtmlEntityService.AddSingle(symbols, "InvisibleTimes;", HtmlEntityService.Convert(8290));
      HtmlEntityService.AddSingle(symbols, "IOcy;", HtmlEntityService.Convert(1025));
      HtmlEntityService.AddSingle(symbols, "Iogon;", HtmlEntityService.Convert(302));
      HtmlEntityService.AddSingle(symbols, "Iopf;", HtmlEntityService.Convert(120128));
      HtmlEntityService.AddSingle(symbols, "Iota;", HtmlEntityService.Convert(921));
      HtmlEntityService.AddSingle(symbols, "Iscr;", HtmlEntityService.Convert(8464));
      HtmlEntityService.AddSingle(symbols, "Itilde;", HtmlEntityService.Convert(296));
      HtmlEntityService.AddSingle(symbols, "Iukcy;", HtmlEntityService.Convert(1030));
      HtmlEntityService.AddBoth(symbols, "Iuml;", HtmlEntityService.Convert(207));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleJ()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "jcirc;", HtmlEntityService.Convert(309));
      HtmlEntityService.AddSingle(symbols, "jcy;", HtmlEntityService.Convert(1081));
      HtmlEntityService.AddSingle(symbols, "jfr;", HtmlEntityService.Convert(120103));
      HtmlEntityService.AddSingle(symbols, "jmath;", HtmlEntityService.Convert(567));
      HtmlEntityService.AddSingle(symbols, "jopf;", HtmlEntityService.Convert(120155));
      HtmlEntityService.AddSingle(symbols, "jscr;", HtmlEntityService.Convert(119999));
      HtmlEntityService.AddSingle(symbols, "jsercy;", HtmlEntityService.Convert(1112));
      HtmlEntityService.AddSingle(symbols, "jukcy;", HtmlEntityService.Convert(1108));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigJ()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Jcirc;", HtmlEntityService.Convert(308));
      HtmlEntityService.AddSingle(symbols, "Jcy;", HtmlEntityService.Convert(1049));
      HtmlEntityService.AddSingle(symbols, "Jfr;", HtmlEntityService.Convert(120077));
      HtmlEntityService.AddSingle(symbols, "Jopf;", HtmlEntityService.Convert(120129));
      HtmlEntityService.AddSingle(symbols, "Jscr;", HtmlEntityService.Convert(119973));
      HtmlEntityService.AddSingle(symbols, "Jsercy;", HtmlEntityService.Convert(1032));
      HtmlEntityService.AddSingle(symbols, "Jukcy;", HtmlEntityService.Convert(1028));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleK()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "kappa;", HtmlEntityService.Convert(954));
      HtmlEntityService.AddSingle(symbols, "kappav;", HtmlEntityService.Convert(1008));
      HtmlEntityService.AddSingle(symbols, "kcedil;", HtmlEntityService.Convert(311));
      HtmlEntityService.AddSingle(symbols, "kcy;", HtmlEntityService.Convert(1082));
      HtmlEntityService.AddSingle(symbols, "kfr;", HtmlEntityService.Convert(120104));
      HtmlEntityService.AddSingle(symbols, "kgreen;", HtmlEntityService.Convert(312));
      HtmlEntityService.AddSingle(symbols, "khcy;", HtmlEntityService.Convert(1093));
      HtmlEntityService.AddSingle(symbols, "kjcy;", HtmlEntityService.Convert(1116));
      HtmlEntityService.AddSingle(symbols, "kopf;", HtmlEntityService.Convert(120156));
      HtmlEntityService.AddSingle(symbols, "kscr;", HtmlEntityService.Convert(120000));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigK()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Kappa;", HtmlEntityService.Convert(922));
      HtmlEntityService.AddSingle(symbols, "Kcedil;", HtmlEntityService.Convert(310));
      HtmlEntityService.AddSingle(symbols, "Kcy;", HtmlEntityService.Convert(1050));
      HtmlEntityService.AddSingle(symbols, "Kfr;", HtmlEntityService.Convert(120078));
      HtmlEntityService.AddSingle(symbols, "KHcy;", HtmlEntityService.Convert(1061));
      HtmlEntityService.AddSingle(symbols, "KJcy;", HtmlEntityService.Convert(1036));
      HtmlEntityService.AddSingle(symbols, "Kopf;", HtmlEntityService.Convert(120130));
      HtmlEntityService.AddSingle(symbols, "Kscr;", HtmlEntityService.Convert(119974));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleL()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "lAarr;", HtmlEntityService.Convert(8666));
      HtmlEntityService.AddSingle(symbols, "lacute;", HtmlEntityService.Convert(314));
      HtmlEntityService.AddSingle(symbols, "laemptyv;", HtmlEntityService.Convert(10676));
      HtmlEntityService.AddSingle(symbols, "lagran;", HtmlEntityService.Convert(8466));
      HtmlEntityService.AddSingle(symbols, "lambda;", HtmlEntityService.Convert(955));
      HtmlEntityService.AddSingle(symbols, "lang;", HtmlEntityService.Convert(10216));
      HtmlEntityService.AddSingle(symbols, "langd;", HtmlEntityService.Convert(10641));
      HtmlEntityService.AddSingle(symbols, "langle;", HtmlEntityService.Convert(10216));
      HtmlEntityService.AddSingle(symbols, "lap;", HtmlEntityService.Convert(10885));
      HtmlEntityService.AddBoth(symbols, "laquo;", HtmlEntityService.Convert(171));
      HtmlEntityService.AddSingle(symbols, "lArr;", HtmlEntityService.Convert(8656));
      HtmlEntityService.AddSingle(symbols, "larr;", HtmlEntityService.Convert(8592));
      HtmlEntityService.AddSingle(symbols, "larrb;", HtmlEntityService.Convert(8676));
      HtmlEntityService.AddSingle(symbols, "larrbfs;", HtmlEntityService.Convert(10527));
      HtmlEntityService.AddSingle(symbols, "larrfs;", HtmlEntityService.Convert(10525));
      HtmlEntityService.AddSingle(symbols, "larrhk;", HtmlEntityService.Convert(8617));
      HtmlEntityService.AddSingle(symbols, "larrlp;", HtmlEntityService.Convert(8619));
      HtmlEntityService.AddSingle(symbols, "larrpl;", HtmlEntityService.Convert(10553));
      HtmlEntityService.AddSingle(symbols, "larrsim;", HtmlEntityService.Convert(10611));
      HtmlEntityService.AddSingle(symbols, "larrtl;", HtmlEntityService.Convert(8610));
      HtmlEntityService.AddSingle(symbols, "lat;", HtmlEntityService.Convert(10923));
      HtmlEntityService.AddSingle(symbols, "lAtail;", HtmlEntityService.Convert(10523));
      HtmlEntityService.AddSingle(symbols, "latail;", HtmlEntityService.Convert(10521));
      HtmlEntityService.AddSingle(symbols, "late;", HtmlEntityService.Convert(10925));
      HtmlEntityService.AddSingle(symbols, "lates;", HtmlEntityService.Convert(10925, 65024));
      HtmlEntityService.AddSingle(symbols, "lBarr;", HtmlEntityService.Convert(10510));
      HtmlEntityService.AddSingle(symbols, "lbarr;", HtmlEntityService.Convert(10508));
      HtmlEntityService.AddSingle(symbols, "lbbrk;", HtmlEntityService.Convert(10098));
      HtmlEntityService.AddSingle(symbols, "lbrace;", HtmlEntityService.Convert(123));
      HtmlEntityService.AddSingle(symbols, "lbrack;", HtmlEntityService.Convert(91));
      HtmlEntityService.AddSingle(symbols, "lbrke;", HtmlEntityService.Convert(10635));
      HtmlEntityService.AddSingle(symbols, "lbrksld;", HtmlEntityService.Convert(10639));
      HtmlEntityService.AddSingle(symbols, "lbrkslu;", HtmlEntityService.Convert(10637));
      HtmlEntityService.AddSingle(symbols, "lcaron;", HtmlEntityService.Convert(318));
      HtmlEntityService.AddSingle(symbols, "lcedil;", HtmlEntityService.Convert(316));
      HtmlEntityService.AddSingle(symbols, "lceil;", HtmlEntityService.Convert(8968));
      HtmlEntityService.AddSingle(symbols, "lcub;", HtmlEntityService.Convert(123));
      HtmlEntityService.AddSingle(symbols, "lcy;", HtmlEntityService.Convert(1083));
      HtmlEntityService.AddSingle(symbols, "ldca;", HtmlEntityService.Convert(10550));
      HtmlEntityService.AddSingle(symbols, "ldquo;", HtmlEntityService.Convert(8220));
      HtmlEntityService.AddSingle(symbols, "ldquor;", HtmlEntityService.Convert(8222));
      HtmlEntityService.AddSingle(symbols, "ldrdhar;", HtmlEntityService.Convert(10599));
      HtmlEntityService.AddSingle(symbols, "ldrushar;", HtmlEntityService.Convert(10571));
      HtmlEntityService.AddSingle(symbols, "ldsh;", HtmlEntityService.Convert(8626));
      HtmlEntityService.AddSingle(symbols, "lE;", HtmlEntityService.Convert(8806));
      HtmlEntityService.AddSingle(symbols, "le;", HtmlEntityService.Convert(8804));
      HtmlEntityService.AddSingle(symbols, "leftarrow;", HtmlEntityService.Convert(8592));
      HtmlEntityService.AddSingle(symbols, "leftarrowtail;", HtmlEntityService.Convert(8610));
      HtmlEntityService.AddSingle(symbols, "leftharpoondown;", HtmlEntityService.Convert(8637));
      HtmlEntityService.AddSingle(symbols, "leftharpoonup;", HtmlEntityService.Convert(8636));
      HtmlEntityService.AddSingle(symbols, "leftleftarrows;", HtmlEntityService.Convert(8647));
      HtmlEntityService.AddSingle(symbols, "leftrightarrow;", HtmlEntityService.Convert(8596));
      HtmlEntityService.AddSingle(symbols, "leftrightarrows;", HtmlEntityService.Convert(8646));
      HtmlEntityService.AddSingle(symbols, "leftrightharpoons;", HtmlEntityService.Convert(8651));
      HtmlEntityService.AddSingle(symbols, "leftrightsquigarrow;", HtmlEntityService.Convert(8621));
      HtmlEntityService.AddSingle(symbols, "leftthreetimes;", HtmlEntityService.Convert(8907));
      HtmlEntityService.AddSingle(symbols, "lEg;", HtmlEntityService.Convert(10891));
      HtmlEntityService.AddSingle(symbols, "leg;", HtmlEntityService.Convert(8922));
      HtmlEntityService.AddSingle(symbols, "leq;", HtmlEntityService.Convert(8804));
      HtmlEntityService.AddSingle(symbols, "leqq;", HtmlEntityService.Convert(8806));
      HtmlEntityService.AddSingle(symbols, "leqslant;", HtmlEntityService.Convert(10877));
      HtmlEntityService.AddSingle(symbols, "les;", HtmlEntityService.Convert(10877));
      HtmlEntityService.AddSingle(symbols, "lescc;", HtmlEntityService.Convert(10920));
      HtmlEntityService.AddSingle(symbols, "lesdot;", HtmlEntityService.Convert(10879));
      HtmlEntityService.AddSingle(symbols, "lesdoto;", HtmlEntityService.Convert(10881));
      HtmlEntityService.AddSingle(symbols, "lesdotor;", HtmlEntityService.Convert(10883));
      HtmlEntityService.AddSingle(symbols, "lesg;", HtmlEntityService.Convert(8922, 65024));
      HtmlEntityService.AddSingle(symbols, "lesges;", HtmlEntityService.Convert(10899));
      HtmlEntityService.AddSingle(symbols, "lessapprox;", HtmlEntityService.Convert(10885));
      HtmlEntityService.AddSingle(symbols, "lessdot;", HtmlEntityService.Convert(8918));
      HtmlEntityService.AddSingle(symbols, "lesseqgtr;", HtmlEntityService.Convert(8922));
      HtmlEntityService.AddSingle(symbols, "lesseqqgtr;", HtmlEntityService.Convert(10891));
      HtmlEntityService.AddSingle(symbols, "lessgtr;", HtmlEntityService.Convert(8822));
      HtmlEntityService.AddSingle(symbols, "lesssim;", HtmlEntityService.Convert(8818));
      HtmlEntityService.AddSingle(symbols, "lfisht;", HtmlEntityService.Convert(10620));
      HtmlEntityService.AddSingle(symbols, "lfloor;", HtmlEntityService.Convert(8970));
      HtmlEntityService.AddSingle(symbols, "lfr;", HtmlEntityService.Convert(120105));
      HtmlEntityService.AddSingle(symbols, "lg;", HtmlEntityService.Convert(8822));
      HtmlEntityService.AddSingle(symbols, "lgE;", HtmlEntityService.Convert(10897));
      HtmlEntityService.AddSingle(symbols, "lHar;", HtmlEntityService.Convert(10594));
      HtmlEntityService.AddSingle(symbols, "lhard;", HtmlEntityService.Convert(8637));
      HtmlEntityService.AddSingle(symbols, "lharu;", HtmlEntityService.Convert(8636));
      HtmlEntityService.AddSingle(symbols, "lharul;", HtmlEntityService.Convert(10602));
      HtmlEntityService.AddSingle(symbols, "lhblk;", HtmlEntityService.Convert(9604));
      HtmlEntityService.AddSingle(symbols, "ljcy;", HtmlEntityService.Convert(1113));
      HtmlEntityService.AddSingle(symbols, "ll;", HtmlEntityService.Convert(8810));
      HtmlEntityService.AddSingle(symbols, "llarr;", HtmlEntityService.Convert(8647));
      HtmlEntityService.AddSingle(symbols, "llcorner;", HtmlEntityService.Convert(8990));
      HtmlEntityService.AddSingle(symbols, "llhard;", HtmlEntityService.Convert(10603));
      HtmlEntityService.AddSingle(symbols, "lltri;", HtmlEntityService.Convert(9722));
      HtmlEntityService.AddSingle(symbols, "lmidot;", HtmlEntityService.Convert(320));
      HtmlEntityService.AddSingle(symbols, "lmoust;", HtmlEntityService.Convert(9136));
      HtmlEntityService.AddSingle(symbols, "lmoustache;", HtmlEntityService.Convert(9136));
      HtmlEntityService.AddSingle(symbols, "lnap;", HtmlEntityService.Convert(10889));
      HtmlEntityService.AddSingle(symbols, "lnapprox;", HtmlEntityService.Convert(10889));
      HtmlEntityService.AddSingle(symbols, "lnE;", HtmlEntityService.Convert(8808));
      HtmlEntityService.AddSingle(symbols, "lne;", HtmlEntityService.Convert(10887));
      HtmlEntityService.AddSingle(symbols, "lneq;", HtmlEntityService.Convert(10887));
      HtmlEntityService.AddSingle(symbols, "lneqq;", HtmlEntityService.Convert(8808));
      HtmlEntityService.AddSingle(symbols, "lnsim;", HtmlEntityService.Convert(8934));
      HtmlEntityService.AddSingle(symbols, "loang;", HtmlEntityService.Convert(10220));
      HtmlEntityService.AddSingle(symbols, "loarr;", HtmlEntityService.Convert(8701));
      HtmlEntityService.AddSingle(symbols, "lobrk;", HtmlEntityService.Convert(10214));
      HtmlEntityService.AddSingle(symbols, "longleftarrow;", HtmlEntityService.Convert(10229));
      HtmlEntityService.AddSingle(symbols, "longleftrightarrow;", HtmlEntityService.Convert(10231));
      HtmlEntityService.AddSingle(symbols, "longmapsto;", HtmlEntityService.Convert(10236));
      HtmlEntityService.AddSingle(symbols, "longrightarrow;", HtmlEntityService.Convert(10230));
      HtmlEntityService.AddSingle(symbols, "looparrowleft;", HtmlEntityService.Convert(8619));
      HtmlEntityService.AddSingle(symbols, "looparrowright;", HtmlEntityService.Convert(8620));
      HtmlEntityService.AddSingle(symbols, "lopar;", HtmlEntityService.Convert(10629));
      HtmlEntityService.AddSingle(symbols, "lopf;", HtmlEntityService.Convert(120157));
      HtmlEntityService.AddSingle(symbols, "loplus;", HtmlEntityService.Convert(10797));
      HtmlEntityService.AddSingle(symbols, "lotimes;", HtmlEntityService.Convert(10804));
      HtmlEntityService.AddSingle(symbols, "lowast;", HtmlEntityService.Convert(8727));
      HtmlEntityService.AddSingle(symbols, "lowbar;", HtmlEntityService.Convert(95));
      HtmlEntityService.AddSingle(symbols, "loz;", HtmlEntityService.Convert(9674));
      HtmlEntityService.AddSingle(symbols, "lozenge;", HtmlEntityService.Convert(9674));
      HtmlEntityService.AddSingle(symbols, "lozf;", HtmlEntityService.Convert(10731));
      HtmlEntityService.AddSingle(symbols, "lpar;", HtmlEntityService.Convert(40));
      HtmlEntityService.AddSingle(symbols, "lparlt;", HtmlEntityService.Convert(10643));
      HtmlEntityService.AddSingle(symbols, "lrarr;", HtmlEntityService.Convert(8646));
      HtmlEntityService.AddSingle(symbols, "lrcorner;", HtmlEntityService.Convert(8991));
      HtmlEntityService.AddSingle(symbols, "lrhar;", HtmlEntityService.Convert(8651));
      HtmlEntityService.AddSingle(symbols, "lrhard;", HtmlEntityService.Convert(10605));
      HtmlEntityService.AddSingle(symbols, "lrm;", HtmlEntityService.Convert(8206));
      HtmlEntityService.AddSingle(symbols, "lrtri;", HtmlEntityService.Convert(8895));
      HtmlEntityService.AddSingle(symbols, "lsaquo;", HtmlEntityService.Convert(8249));
      HtmlEntityService.AddSingle(symbols, "lscr;", HtmlEntityService.Convert(120001));
      HtmlEntityService.AddSingle(symbols, "lsh;", HtmlEntityService.Convert(8624));
      HtmlEntityService.AddSingle(symbols, "lsim;", HtmlEntityService.Convert(8818));
      HtmlEntityService.AddSingle(symbols, "lsime;", HtmlEntityService.Convert(10893));
      HtmlEntityService.AddSingle(symbols, "lsimg;", HtmlEntityService.Convert(10895));
      HtmlEntityService.AddSingle(symbols, "lsqb;", HtmlEntityService.Convert(91));
      HtmlEntityService.AddSingle(symbols, "lsquo;", HtmlEntityService.Convert(8216));
      HtmlEntityService.AddSingle(symbols, "lsquor;", HtmlEntityService.Convert(8218));
      HtmlEntityService.AddSingle(symbols, "lstrok;", HtmlEntityService.Convert(322));
      HtmlEntityService.AddBoth(symbols, "lt;", HtmlEntityService.Convert(60));
      HtmlEntityService.AddSingle(symbols, "ltcc;", HtmlEntityService.Convert(10918));
      HtmlEntityService.AddSingle(symbols, "ltcir;", HtmlEntityService.Convert(10873));
      HtmlEntityService.AddSingle(symbols, "ltdot;", HtmlEntityService.Convert(8918));
      HtmlEntityService.AddSingle(symbols, "lthree;", HtmlEntityService.Convert(8907));
      HtmlEntityService.AddSingle(symbols, "ltimes;", HtmlEntityService.Convert(8905));
      HtmlEntityService.AddSingle(symbols, "ltlarr;", HtmlEntityService.Convert(10614));
      HtmlEntityService.AddSingle(symbols, "ltquest;", HtmlEntityService.Convert(10875));
      HtmlEntityService.AddSingle(symbols, "ltri;", HtmlEntityService.Convert(9667));
      HtmlEntityService.AddSingle(symbols, "ltrie;", HtmlEntityService.Convert(8884));
      HtmlEntityService.AddSingle(symbols, "ltrif;", HtmlEntityService.Convert(9666));
      HtmlEntityService.AddSingle(symbols, "ltrPar;", HtmlEntityService.Convert(10646));
      HtmlEntityService.AddSingle(symbols, "lurdshar;", HtmlEntityService.Convert(10570));
      HtmlEntityService.AddSingle(symbols, "luruhar;", HtmlEntityService.Convert(10598));
      HtmlEntityService.AddSingle(symbols, "lvertneqq;", HtmlEntityService.Convert(8808, 65024));
      HtmlEntityService.AddSingle(symbols, "lvnE;", HtmlEntityService.Convert(8808, 65024));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigL()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Lacute;", HtmlEntityService.Convert(313));
      HtmlEntityService.AddSingle(symbols, "Lambda;", HtmlEntityService.Convert(923));
      HtmlEntityService.AddSingle(symbols, "Lang;", HtmlEntityService.Convert(10218));
      HtmlEntityService.AddSingle(symbols, "Laplacetrf;", HtmlEntityService.Convert(8466));
      HtmlEntityService.AddSingle(symbols, "Larr;", HtmlEntityService.Convert(8606));
      HtmlEntityService.AddSingle(symbols, "Lcaron;", HtmlEntityService.Convert(317));
      HtmlEntityService.AddSingle(symbols, "Lcedil;", HtmlEntityService.Convert(315));
      HtmlEntityService.AddSingle(symbols, "Lcy;", HtmlEntityService.Convert(1051));
      HtmlEntityService.AddSingle(symbols, "LeftAngleBracket;", HtmlEntityService.Convert(10216));
      HtmlEntityService.AddSingle(symbols, "LeftArrow;", HtmlEntityService.Convert(8592));
      HtmlEntityService.AddSingle(symbols, "Leftarrow;", HtmlEntityService.Convert(8656));
      HtmlEntityService.AddSingle(symbols, "LeftArrowBar;", HtmlEntityService.Convert(8676));
      HtmlEntityService.AddSingle(symbols, "LeftArrowRightArrow;", HtmlEntityService.Convert(8646));
      HtmlEntityService.AddSingle(symbols, "LeftCeiling;", HtmlEntityService.Convert(8968));
      HtmlEntityService.AddSingle(symbols, "LeftDoubleBracket;", HtmlEntityService.Convert(10214));
      HtmlEntityService.AddSingle(symbols, "LeftDownTeeVector;", HtmlEntityService.Convert(10593));
      HtmlEntityService.AddSingle(symbols, "LeftDownVector;", HtmlEntityService.Convert(8643));
      HtmlEntityService.AddSingle(symbols, "LeftDownVectorBar;", HtmlEntityService.Convert(10585));
      HtmlEntityService.AddSingle(symbols, "LeftFloor;", HtmlEntityService.Convert(8970));
      HtmlEntityService.AddSingle(symbols, "LeftRightArrow;", HtmlEntityService.Convert(8596));
      HtmlEntityService.AddSingle(symbols, "Leftrightarrow;", HtmlEntityService.Convert(8660));
      HtmlEntityService.AddSingle(symbols, "LeftRightVector;", HtmlEntityService.Convert(10574));
      HtmlEntityService.AddSingle(symbols, "LeftTee;", HtmlEntityService.Convert(8867));
      HtmlEntityService.AddSingle(symbols, "LeftTeeArrow;", HtmlEntityService.Convert(8612));
      HtmlEntityService.AddSingle(symbols, "LeftTeeVector;", HtmlEntityService.Convert(10586));
      HtmlEntityService.AddSingle(symbols, "LeftTriangle;", HtmlEntityService.Convert(8882));
      HtmlEntityService.AddSingle(symbols, "LeftTriangleBar;", HtmlEntityService.Convert(10703));
      HtmlEntityService.AddSingle(symbols, "LeftTriangleEqual;", HtmlEntityService.Convert(8884));
      HtmlEntityService.AddSingle(symbols, "LeftUpDownVector;", HtmlEntityService.Convert(10577));
      HtmlEntityService.AddSingle(symbols, "LeftUpTeeVector;", HtmlEntityService.Convert(10592));
      HtmlEntityService.AddSingle(symbols, "LeftUpVector;", HtmlEntityService.Convert(8639));
      HtmlEntityService.AddSingle(symbols, "LeftUpVectorBar;", HtmlEntityService.Convert(10584));
      HtmlEntityService.AddSingle(symbols, "LeftVector;", HtmlEntityService.Convert(8636));
      HtmlEntityService.AddSingle(symbols, "LeftVectorBar;", HtmlEntityService.Convert(10578));
      HtmlEntityService.AddSingle(symbols, "LessEqualGreater;", HtmlEntityService.Convert(8922));
      HtmlEntityService.AddSingle(symbols, "LessFullEqual;", HtmlEntityService.Convert(8806));
      HtmlEntityService.AddSingle(symbols, "LessGreater;", HtmlEntityService.Convert(8822));
      HtmlEntityService.AddSingle(symbols, "LessLess;", HtmlEntityService.Convert(10913));
      HtmlEntityService.AddSingle(symbols, "LessSlantEqual;", HtmlEntityService.Convert(10877));
      HtmlEntityService.AddSingle(symbols, "LessTilde;", HtmlEntityService.Convert(8818));
      HtmlEntityService.AddSingle(symbols, "Lfr;", HtmlEntityService.Convert(120079));
      HtmlEntityService.AddSingle(symbols, "LJcy;", HtmlEntityService.Convert(1033));
      HtmlEntityService.AddSingle(symbols, "Ll;", HtmlEntityService.Convert(8920));
      HtmlEntityService.AddSingle(symbols, "Lleftarrow;", HtmlEntityService.Convert(8666));
      HtmlEntityService.AddSingle(symbols, "Lmidot;", HtmlEntityService.Convert(319));
      HtmlEntityService.AddSingle(symbols, "LongLeftArrow;", HtmlEntityService.Convert(10229));
      HtmlEntityService.AddSingle(symbols, "Longleftarrow;", HtmlEntityService.Convert(10232));
      HtmlEntityService.AddSingle(symbols, "LongLeftRightArrow;", HtmlEntityService.Convert(10231));
      HtmlEntityService.AddSingle(symbols, "Longleftrightarrow;", HtmlEntityService.Convert(10234));
      HtmlEntityService.AddSingle(symbols, "LongRightArrow;", HtmlEntityService.Convert(10230));
      HtmlEntityService.AddSingle(symbols, "Longrightarrow;", HtmlEntityService.Convert(10233));
      HtmlEntityService.AddSingle(symbols, "Lopf;", HtmlEntityService.Convert(120131));
      HtmlEntityService.AddSingle(symbols, "LowerLeftArrow;", HtmlEntityService.Convert(8601));
      HtmlEntityService.AddSingle(symbols, "LowerRightArrow;", HtmlEntityService.Convert(8600));
      HtmlEntityService.AddSingle(symbols, "Lscr;", HtmlEntityService.Convert(8466));
      HtmlEntityService.AddSingle(symbols, "Lsh;", HtmlEntityService.Convert(8624));
      HtmlEntityService.AddSingle(symbols, "Lstrok;", HtmlEntityService.Convert(321));
      HtmlEntityService.AddBoth(symbols, "LT;", HtmlEntityService.Convert(60));
      HtmlEntityService.AddSingle(symbols, "Lt;", HtmlEntityService.Convert(8810));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleM()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddBoth(symbols, "macr;", HtmlEntityService.Convert(175));
      HtmlEntityService.AddSingle(symbols, "male;", HtmlEntityService.Convert(9794));
      HtmlEntityService.AddSingle(symbols, "malt;", HtmlEntityService.Convert(10016));
      HtmlEntityService.AddSingle(symbols, "maltese;", HtmlEntityService.Convert(10016));
      HtmlEntityService.AddSingle(symbols, "map;", HtmlEntityService.Convert(8614));
      HtmlEntityService.AddSingle(symbols, "mapsto;", HtmlEntityService.Convert(8614));
      HtmlEntityService.AddSingle(symbols, "mapstodown;", HtmlEntityService.Convert(8615));
      HtmlEntityService.AddSingle(symbols, "mapstoleft;", HtmlEntityService.Convert(8612));
      HtmlEntityService.AddSingle(symbols, "mapstoup;", HtmlEntityService.Convert(8613));
      HtmlEntityService.AddSingle(symbols, "marker;", HtmlEntityService.Convert(9646));
      HtmlEntityService.AddSingle(symbols, "mcomma;", HtmlEntityService.Convert(10793));
      HtmlEntityService.AddSingle(symbols, "mcy;", HtmlEntityService.Convert(1084));
      HtmlEntityService.AddSingle(symbols, "mdash;", HtmlEntityService.Convert(8212));
      HtmlEntityService.AddSingle(symbols, "mDDot;", HtmlEntityService.Convert(8762));
      HtmlEntityService.AddSingle(symbols, "measuredangle;", HtmlEntityService.Convert(8737));
      HtmlEntityService.AddSingle(symbols, "mfr;", HtmlEntityService.Convert(120106));
      HtmlEntityService.AddSingle(symbols, "mho;", HtmlEntityService.Convert(8487));
      HtmlEntityService.AddBoth(symbols, "micro;", HtmlEntityService.Convert(181));
      HtmlEntityService.AddSingle(symbols, "mid;", HtmlEntityService.Convert(8739));
      HtmlEntityService.AddSingle(symbols, "midast;", HtmlEntityService.Convert(42));
      HtmlEntityService.AddSingle(symbols, "midcir;", HtmlEntityService.Convert(10992));
      HtmlEntityService.AddBoth(symbols, "middot;", HtmlEntityService.Convert(183));
      HtmlEntityService.AddSingle(symbols, "minus;", HtmlEntityService.Convert(8722));
      HtmlEntityService.AddSingle(symbols, "minusb;", HtmlEntityService.Convert(8863));
      HtmlEntityService.AddSingle(symbols, "minusd;", HtmlEntityService.Convert(8760));
      HtmlEntityService.AddSingle(symbols, "minusdu;", HtmlEntityService.Convert(10794));
      HtmlEntityService.AddSingle(symbols, "mlcp;", HtmlEntityService.Convert(10971));
      HtmlEntityService.AddSingle(symbols, "mldr;", HtmlEntityService.Convert(8230));
      HtmlEntityService.AddSingle(symbols, "mnplus;", HtmlEntityService.Convert(8723));
      HtmlEntityService.AddSingle(symbols, "models;", HtmlEntityService.Convert(8871));
      HtmlEntityService.AddSingle(symbols, "mopf;", HtmlEntityService.Convert(120158));
      HtmlEntityService.AddSingle(symbols, "mp;", HtmlEntityService.Convert(8723));
      HtmlEntityService.AddSingle(symbols, "mscr;", HtmlEntityService.Convert(120002));
      HtmlEntityService.AddSingle(symbols, "mstpos;", HtmlEntityService.Convert(8766));
      HtmlEntityService.AddSingle(symbols, "mu;", HtmlEntityService.Convert(956));
      HtmlEntityService.AddSingle(symbols, "multimap;", HtmlEntityService.Convert(8888));
      HtmlEntityService.AddSingle(symbols, "mumap;", HtmlEntityService.Convert(8888));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigM()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Map;", HtmlEntityService.Convert(10501));
      HtmlEntityService.AddSingle(symbols, "Mcy;", HtmlEntityService.Convert(1052));
      HtmlEntityService.AddSingle(symbols, "MediumSpace;", HtmlEntityService.Convert(8287));
      HtmlEntityService.AddSingle(symbols, "Mellintrf;", HtmlEntityService.Convert(8499));
      HtmlEntityService.AddSingle(symbols, "Mfr;", HtmlEntityService.Convert(120080));
      HtmlEntityService.AddSingle(symbols, "MinusPlus;", HtmlEntityService.Convert(8723));
      HtmlEntityService.AddSingle(symbols, "Mopf;", HtmlEntityService.Convert(120132));
      HtmlEntityService.AddSingle(symbols, "Mscr;", HtmlEntityService.Convert(8499));
      HtmlEntityService.AddSingle(symbols, "Mu;", HtmlEntityService.Convert(924));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleN()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "nabla;", HtmlEntityService.Convert(8711));
      HtmlEntityService.AddSingle(symbols, "nacute;", HtmlEntityService.Convert(324));
      HtmlEntityService.AddSingle(symbols, "nang;", HtmlEntityService.Convert(8736, 8402));
      HtmlEntityService.AddSingle(symbols, "nap;", HtmlEntityService.Convert(8777));
      HtmlEntityService.AddSingle(symbols, "napE;", HtmlEntityService.Convert(10864, 824));
      HtmlEntityService.AddSingle(symbols, "napid;", HtmlEntityService.Convert(8779, 824));
      HtmlEntityService.AddSingle(symbols, "napos;", HtmlEntityService.Convert(329));
      HtmlEntityService.AddSingle(symbols, "napprox;", HtmlEntityService.Convert(8777));
      HtmlEntityService.AddSingle(symbols, "natur;", HtmlEntityService.Convert(9838));
      HtmlEntityService.AddSingle(symbols, "natural;", HtmlEntityService.Convert(9838));
      HtmlEntityService.AddSingle(symbols, "naturals;", HtmlEntityService.Convert(8469));
      HtmlEntityService.AddBoth(symbols, "nbsp;", HtmlEntityService.Convert(160));
      HtmlEntityService.AddSingle(symbols, "nbump;", HtmlEntityService.Convert(8782, 824));
      HtmlEntityService.AddSingle(symbols, "nbumpe;", HtmlEntityService.Convert(8783, 824));
      HtmlEntityService.AddSingle(symbols, "ncap;", HtmlEntityService.Convert(10819));
      HtmlEntityService.AddSingle(symbols, "ncaron;", HtmlEntityService.Convert(328));
      HtmlEntityService.AddSingle(symbols, "ncedil;", HtmlEntityService.Convert(326));
      HtmlEntityService.AddSingle(symbols, "ncong;", HtmlEntityService.Convert(8775));
      HtmlEntityService.AddSingle(symbols, "ncongdot;", HtmlEntityService.Convert(10861, 824));
      HtmlEntityService.AddSingle(symbols, "ncup;", HtmlEntityService.Convert(10818));
      HtmlEntityService.AddSingle(symbols, "ncy;", HtmlEntityService.Convert(1085));
      HtmlEntityService.AddSingle(symbols, "ndash;", HtmlEntityService.Convert(8211));
      HtmlEntityService.AddSingle(symbols, "ne;", HtmlEntityService.Convert(8800));
      HtmlEntityService.AddSingle(symbols, "nearhk;", HtmlEntityService.Convert(10532));
      HtmlEntityService.AddSingle(symbols, "neArr;", HtmlEntityService.Convert(8663));
      HtmlEntityService.AddSingle(symbols, "nearr;", HtmlEntityService.Convert(8599));
      HtmlEntityService.AddSingle(symbols, "nearrow;", HtmlEntityService.Convert(8599));
      HtmlEntityService.AddSingle(symbols, "nedot;", HtmlEntityService.Convert(8784, 824));
      HtmlEntityService.AddSingle(symbols, "nequiv;", HtmlEntityService.Convert(8802));
      HtmlEntityService.AddSingle(symbols, "nesear;", HtmlEntityService.Convert(10536));
      HtmlEntityService.AddSingle(symbols, "nesim;", HtmlEntityService.Convert(8770, 824));
      HtmlEntityService.AddSingle(symbols, "nexist;", HtmlEntityService.Convert(8708));
      HtmlEntityService.AddSingle(symbols, "nexists;", HtmlEntityService.Convert(8708));
      HtmlEntityService.AddSingle(symbols, "nfr;", HtmlEntityService.Convert(120107));
      HtmlEntityService.AddSingle(symbols, "ngE;", HtmlEntityService.Convert(8807, 824));
      HtmlEntityService.AddSingle(symbols, "nge;", HtmlEntityService.Convert(8817));
      HtmlEntityService.AddSingle(symbols, "ngeq;", HtmlEntityService.Convert(8817));
      HtmlEntityService.AddSingle(symbols, "ngeqq;", HtmlEntityService.Convert(8807, 824));
      HtmlEntityService.AddSingle(symbols, "ngeqslant;", HtmlEntityService.Convert(10878, 824));
      HtmlEntityService.AddSingle(symbols, "nges;", HtmlEntityService.Convert(10878, 824));
      HtmlEntityService.AddSingle(symbols, "nGg;", HtmlEntityService.Convert(8921, 824));
      HtmlEntityService.AddSingle(symbols, "ngsim;", HtmlEntityService.Convert(8821));
      HtmlEntityService.AddSingle(symbols, "nGt;", HtmlEntityService.Convert(8811, 8402));
      HtmlEntityService.AddSingle(symbols, "ngt;", HtmlEntityService.Convert(8815));
      HtmlEntityService.AddSingle(symbols, "ngtr;", HtmlEntityService.Convert(8815));
      HtmlEntityService.AddSingle(symbols, "nGtv;", HtmlEntityService.Convert(8811, 824));
      HtmlEntityService.AddSingle(symbols, "nhArr;", HtmlEntityService.Convert(8654));
      HtmlEntityService.AddSingle(symbols, "nharr;", HtmlEntityService.Convert(8622));
      HtmlEntityService.AddSingle(symbols, "nhpar;", HtmlEntityService.Convert(10994));
      HtmlEntityService.AddSingle(symbols, "ni;", HtmlEntityService.Convert(8715));
      HtmlEntityService.AddSingle(symbols, "nis;", HtmlEntityService.Convert(8956));
      HtmlEntityService.AddSingle(symbols, "nisd;", HtmlEntityService.Convert(8954));
      HtmlEntityService.AddSingle(symbols, "niv;", HtmlEntityService.Convert(8715));
      HtmlEntityService.AddSingle(symbols, "njcy;", HtmlEntityService.Convert(1114));
      HtmlEntityService.AddSingle(symbols, "nlArr;", HtmlEntityService.Convert(8653));
      HtmlEntityService.AddSingle(symbols, "nlarr;", HtmlEntityService.Convert(8602));
      HtmlEntityService.AddSingle(symbols, "nldr;", HtmlEntityService.Convert(8229));
      HtmlEntityService.AddSingle(symbols, "nlE;", HtmlEntityService.Convert(8806, 824));
      HtmlEntityService.AddSingle(symbols, "nle;", HtmlEntityService.Convert(8816));
      HtmlEntityService.AddSingle(symbols, "nLeftarrow;", HtmlEntityService.Convert(8653));
      HtmlEntityService.AddSingle(symbols, "nleftarrow;", HtmlEntityService.Convert(8602));
      HtmlEntityService.AddSingle(symbols, "nLeftrightarrow;", HtmlEntityService.Convert(8654));
      HtmlEntityService.AddSingle(symbols, "nleftrightarrow;", HtmlEntityService.Convert(8622));
      HtmlEntityService.AddSingle(symbols, "nleq;", HtmlEntityService.Convert(8816));
      HtmlEntityService.AddSingle(symbols, "nleqq;", HtmlEntityService.Convert(8806, 824));
      HtmlEntityService.AddSingle(symbols, "nleqslant;", HtmlEntityService.Convert(10877, 824));
      HtmlEntityService.AddSingle(symbols, "nles;", HtmlEntityService.Convert(10877, 824));
      HtmlEntityService.AddSingle(symbols, "nless;", HtmlEntityService.Convert(8814));
      HtmlEntityService.AddSingle(symbols, "nLl;", HtmlEntityService.Convert(8920, 824));
      HtmlEntityService.AddSingle(symbols, "nlsim;", HtmlEntityService.Convert(8820));
      HtmlEntityService.AddSingle(symbols, "nLt;", HtmlEntityService.Convert(8810, 8402));
      HtmlEntityService.AddSingle(symbols, "nlt;", HtmlEntityService.Convert(8814));
      HtmlEntityService.AddSingle(symbols, "nltri;", HtmlEntityService.Convert(8938));
      HtmlEntityService.AddSingle(symbols, "nltrie;", HtmlEntityService.Convert(8940));
      HtmlEntityService.AddSingle(symbols, "nLtv;", HtmlEntityService.Convert(8810, 824));
      HtmlEntityService.AddSingle(symbols, "nmid;", HtmlEntityService.Convert(8740));
      HtmlEntityService.AddSingle(symbols, "nopf;", HtmlEntityService.Convert(120159));
      HtmlEntityService.AddBoth(symbols, "not;", HtmlEntityService.Convert(172));
      HtmlEntityService.AddSingle(symbols, "notin;", HtmlEntityService.Convert(8713));
      HtmlEntityService.AddSingle(symbols, "notindot;", HtmlEntityService.Convert(8949, 824));
      HtmlEntityService.AddSingle(symbols, "notinE;", HtmlEntityService.Convert(8953, 824));
      HtmlEntityService.AddSingle(symbols, "notinva;", HtmlEntityService.Convert(8713));
      HtmlEntityService.AddSingle(symbols, "notinvb;", HtmlEntityService.Convert(8951));
      HtmlEntityService.AddSingle(symbols, "notinvc;", HtmlEntityService.Convert(8950));
      HtmlEntityService.AddSingle(symbols, "notni;", HtmlEntityService.Convert(8716));
      HtmlEntityService.AddSingle(symbols, "notniva;", HtmlEntityService.Convert(8716));
      HtmlEntityService.AddSingle(symbols, "notnivb;", HtmlEntityService.Convert(8958));
      HtmlEntityService.AddSingle(symbols, "notnivc;", HtmlEntityService.Convert(8957));
      HtmlEntityService.AddSingle(symbols, "npar;", HtmlEntityService.Convert(8742));
      HtmlEntityService.AddSingle(symbols, "nparallel;", HtmlEntityService.Convert(8742));
      HtmlEntityService.AddSingle(symbols, "nparsl;", HtmlEntityService.Convert(11005, 8421));
      HtmlEntityService.AddSingle(symbols, "npart;", HtmlEntityService.Convert(8706, 824));
      HtmlEntityService.AddSingle(symbols, "npolint;", HtmlEntityService.Convert(10772));
      HtmlEntityService.AddSingle(symbols, "npr;", HtmlEntityService.Convert(8832));
      HtmlEntityService.AddSingle(symbols, "nprcue;", HtmlEntityService.Convert(8928));
      HtmlEntityService.AddSingle(symbols, "npre;", HtmlEntityService.Convert(10927, 824));
      HtmlEntityService.AddSingle(symbols, "nprec;", HtmlEntityService.Convert(8832));
      HtmlEntityService.AddSingle(symbols, "npreceq;", HtmlEntityService.Convert(10927, 824));
      HtmlEntityService.AddSingle(symbols, "nrArr;", HtmlEntityService.Convert(8655));
      HtmlEntityService.AddSingle(symbols, "nrarr;", HtmlEntityService.Convert(8603));
      HtmlEntityService.AddSingle(symbols, "nrarrc;", HtmlEntityService.Convert(10547, 824));
      HtmlEntityService.AddSingle(symbols, "nrarrw;", HtmlEntityService.Convert(8605, 824));
      HtmlEntityService.AddSingle(symbols, "nRightarrow;", HtmlEntityService.Convert(8655));
      HtmlEntityService.AddSingle(symbols, "nrightarrow;", HtmlEntityService.Convert(8603));
      HtmlEntityService.AddSingle(symbols, "nrtri;", HtmlEntityService.Convert(8939));
      HtmlEntityService.AddSingle(symbols, "nrtrie;", HtmlEntityService.Convert(8941));
      HtmlEntityService.AddSingle(symbols, "nsc;", HtmlEntityService.Convert(8833));
      HtmlEntityService.AddSingle(symbols, "nsccue;", HtmlEntityService.Convert(8929));
      HtmlEntityService.AddSingle(symbols, "nsce;", HtmlEntityService.Convert(10928, 824));
      HtmlEntityService.AddSingle(symbols, "nscr;", HtmlEntityService.Convert(120003));
      HtmlEntityService.AddSingle(symbols, "nshortmid;", HtmlEntityService.Convert(8740));
      HtmlEntityService.AddSingle(symbols, "nshortparallel;", HtmlEntityService.Convert(8742));
      HtmlEntityService.AddSingle(symbols, "nsim;", HtmlEntityService.Convert(8769));
      HtmlEntityService.AddSingle(symbols, "nsime;", HtmlEntityService.Convert(8772));
      HtmlEntityService.AddSingle(symbols, "nsimeq;", HtmlEntityService.Convert(8772));
      HtmlEntityService.AddSingle(symbols, "nsmid;", HtmlEntityService.Convert(8740));
      HtmlEntityService.AddSingle(symbols, "nspar;", HtmlEntityService.Convert(8742));
      HtmlEntityService.AddSingle(symbols, "nsqsube;", HtmlEntityService.Convert(8930));
      HtmlEntityService.AddSingle(symbols, "nsqsupe;", HtmlEntityService.Convert(8931));
      HtmlEntityService.AddSingle(symbols, "nsub;", HtmlEntityService.Convert(8836));
      HtmlEntityService.AddSingle(symbols, "nsubE;", HtmlEntityService.Convert(10949, 824));
      HtmlEntityService.AddSingle(symbols, "nsube;", HtmlEntityService.Convert(8840));
      HtmlEntityService.AddSingle(symbols, "nsubset;", HtmlEntityService.Convert(8834, 8402));
      HtmlEntityService.AddSingle(symbols, "nsubseteq;", HtmlEntityService.Convert(8840));
      HtmlEntityService.AddSingle(symbols, "nsubseteqq;", HtmlEntityService.Convert(10949, 824));
      HtmlEntityService.AddSingle(symbols, "nsucc;", HtmlEntityService.Convert(8833));
      HtmlEntityService.AddSingle(symbols, "nsucceq;", HtmlEntityService.Convert(10928, 824));
      HtmlEntityService.AddSingle(symbols, "nsup;", HtmlEntityService.Convert(8837));
      HtmlEntityService.AddSingle(symbols, "nsupE;", HtmlEntityService.Convert(10950, 824));
      HtmlEntityService.AddSingle(symbols, "nsupe;", HtmlEntityService.Convert(8841));
      HtmlEntityService.AddSingle(symbols, "nsupset;", HtmlEntityService.Convert(8835, 8402));
      HtmlEntityService.AddSingle(symbols, "nsupseteq;", HtmlEntityService.Convert(8841));
      HtmlEntityService.AddSingle(symbols, "nsupseteqq;", HtmlEntityService.Convert(10950, 824));
      HtmlEntityService.AddSingle(symbols, "ntgl;", HtmlEntityService.Convert(8825));
      HtmlEntityService.AddBoth(symbols, "ntilde;", HtmlEntityService.Convert(241));
      HtmlEntityService.AddSingle(symbols, "ntlg;", HtmlEntityService.Convert(8824));
      HtmlEntityService.AddSingle(symbols, "ntriangleleft;", HtmlEntityService.Convert(8938));
      HtmlEntityService.AddSingle(symbols, "ntrianglelefteq;", HtmlEntityService.Convert(8940));
      HtmlEntityService.AddSingle(symbols, "ntriangleright;", HtmlEntityService.Convert(8939));
      HtmlEntityService.AddSingle(symbols, "ntrianglerighteq;", HtmlEntityService.Convert(8941));
      HtmlEntityService.AddSingle(symbols, "nu;", HtmlEntityService.Convert(957));
      HtmlEntityService.AddSingle(symbols, "num;", HtmlEntityService.Convert(35));
      HtmlEntityService.AddSingle(symbols, "numero;", HtmlEntityService.Convert(8470));
      HtmlEntityService.AddSingle(symbols, "numsp;", HtmlEntityService.Convert(8199));
      HtmlEntityService.AddSingle(symbols, "nvap;", HtmlEntityService.Convert(8781, 8402));
      HtmlEntityService.AddSingle(symbols, "nVDash;", HtmlEntityService.Convert(8879));
      HtmlEntityService.AddSingle(symbols, "nVdash;", HtmlEntityService.Convert(8878));
      HtmlEntityService.AddSingle(symbols, "nvDash;", HtmlEntityService.Convert(8877));
      HtmlEntityService.AddSingle(symbols, "nvdash;", HtmlEntityService.Convert(8876));
      HtmlEntityService.AddSingle(symbols, "nvge;", HtmlEntityService.Convert(8805, 8402));
      HtmlEntityService.AddSingle(symbols, "nvgt;", HtmlEntityService.Convert(62, 8402));
      HtmlEntityService.AddSingle(symbols, "nvHarr;", HtmlEntityService.Convert(10500));
      HtmlEntityService.AddSingle(symbols, "nvinfin;", HtmlEntityService.Convert(10718));
      HtmlEntityService.AddSingle(symbols, "nvlArr;", HtmlEntityService.Convert(10498));
      HtmlEntityService.AddSingle(symbols, "nvle;", HtmlEntityService.Convert(8804, 8402));
      HtmlEntityService.AddSingle(symbols, "nvlt;", HtmlEntityService.Convert(60, 8402));
      HtmlEntityService.AddSingle(symbols, "nvltrie;", HtmlEntityService.Convert(8884, 8402));
      HtmlEntityService.AddSingle(symbols, "nvrArr;", HtmlEntityService.Convert(10499));
      HtmlEntityService.AddSingle(symbols, "nvrtrie;", HtmlEntityService.Convert(8885, 8402));
      HtmlEntityService.AddSingle(symbols, "nvsim;", HtmlEntityService.Convert(8764, 8402));
      HtmlEntityService.AddSingle(symbols, "nwarhk;", HtmlEntityService.Convert(10531));
      HtmlEntityService.AddSingle(symbols, "nwArr;", HtmlEntityService.Convert(8662));
      HtmlEntityService.AddSingle(symbols, "nwarr;", HtmlEntityService.Convert(8598));
      HtmlEntityService.AddSingle(symbols, "nwarrow;", HtmlEntityService.Convert(8598));
      HtmlEntityService.AddSingle(symbols, "nwnear;", HtmlEntityService.Convert(10535));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigN()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Nacute;", HtmlEntityService.Convert(323));
      HtmlEntityService.AddSingle(symbols, "Ncaron;", HtmlEntityService.Convert(327));
      HtmlEntityService.AddSingle(symbols, "Ncedil;", HtmlEntityService.Convert(325));
      HtmlEntityService.AddSingle(symbols, "NegativeMediumSpace;", HtmlEntityService.Convert(8203));
      HtmlEntityService.AddSingle(symbols, "NegativeThickSpace;", HtmlEntityService.Convert(8203));
      HtmlEntityService.AddSingle(symbols, "NegativeThinSpace;", HtmlEntityService.Convert(8203));
      HtmlEntityService.AddSingle(symbols, "NegativeVeryThinSpace;", HtmlEntityService.Convert(8203));
      HtmlEntityService.AddSingle(symbols, "NestedGreaterGreater;", HtmlEntityService.Convert(8811));
      HtmlEntityService.AddSingle(symbols, "NestedLessLess;", HtmlEntityService.Convert(8810));
      HtmlEntityService.AddSingle(symbols, "Ncy;", HtmlEntityService.Convert(1053));
      HtmlEntityService.AddSingle(symbols, "Nfr;", HtmlEntityService.Convert(120081));
      HtmlEntityService.AddSingle(symbols, "NoBreak;", HtmlEntityService.Convert(8288));
      HtmlEntityService.AddSingle(symbols, "NonBreakingSpace;", HtmlEntityService.Convert(160));
      HtmlEntityService.AddSingle(symbols, "Nopf;", HtmlEntityService.Convert(8469));
      HtmlEntityService.AddSingle(symbols, "NewLine;", HtmlEntityService.Convert(10));
      HtmlEntityService.AddSingle(symbols, "NJcy;", HtmlEntityService.Convert(1034));
      HtmlEntityService.AddSingle(symbols, "Not;", HtmlEntityService.Convert(10988));
      HtmlEntityService.AddSingle(symbols, "NotCongruent;", HtmlEntityService.Convert(8802));
      HtmlEntityService.AddSingle(symbols, "NotCupCap;", HtmlEntityService.Convert(8813));
      HtmlEntityService.AddSingle(symbols, "NotDoubleVerticalBar;", HtmlEntityService.Convert(8742));
      HtmlEntityService.AddSingle(symbols, "NotElement;", HtmlEntityService.Convert(8713));
      HtmlEntityService.AddSingle(symbols, "NotEqual;", HtmlEntityService.Convert(8800));
      HtmlEntityService.AddSingle(symbols, "NotEqualTilde;", HtmlEntityService.Convert(8770, 824));
      HtmlEntityService.AddSingle(symbols, "NotExists;", HtmlEntityService.Convert(8708));
      HtmlEntityService.AddSingle(symbols, "NotGreater;", HtmlEntityService.Convert(8815));
      HtmlEntityService.AddSingle(symbols, "NotGreaterEqual;", HtmlEntityService.Convert(8817));
      HtmlEntityService.AddSingle(symbols, "NotGreaterFullEqual;", HtmlEntityService.Convert(8807, 824));
      HtmlEntityService.AddSingle(symbols, "NotGreaterGreater;", HtmlEntityService.Convert(8811, 824));
      HtmlEntityService.AddSingle(symbols, "NotGreaterLess;", HtmlEntityService.Convert(8825));
      HtmlEntityService.AddSingle(symbols, "NotGreaterSlantEqual;", HtmlEntityService.Convert(10878, 824));
      HtmlEntityService.AddSingle(symbols, "NotGreaterTilde;", HtmlEntityService.Convert(8821));
      HtmlEntityService.AddSingle(symbols, "NotHumpDownHump;", HtmlEntityService.Convert(8782, 824));
      HtmlEntityService.AddSingle(symbols, "NotHumpEqual;", HtmlEntityService.Convert(8783, 824));
      HtmlEntityService.AddSingle(symbols, "NotLeftTriangle;", HtmlEntityService.Convert(8938));
      HtmlEntityService.AddSingle(symbols, "NotLeftTriangleBar;", HtmlEntityService.Convert(10703, 824));
      HtmlEntityService.AddSingle(symbols, "NotLeftTriangleEqual;", HtmlEntityService.Convert(8940));
      HtmlEntityService.AddSingle(symbols, "NotLess;", HtmlEntityService.Convert(8814));
      HtmlEntityService.AddSingle(symbols, "NotLessEqual;", HtmlEntityService.Convert(8816));
      HtmlEntityService.AddSingle(symbols, "NotLessGreater;", HtmlEntityService.Convert(8824));
      HtmlEntityService.AddSingle(symbols, "NotLessLess;", HtmlEntityService.Convert(8810, 824));
      HtmlEntityService.AddSingle(symbols, "NotLessSlantEqual;", HtmlEntityService.Convert(10877, 824));
      HtmlEntityService.AddSingle(symbols, "NotLessTilde;", HtmlEntityService.Convert(8820));
      HtmlEntityService.AddSingle(symbols, "NotNestedGreaterGreater;", HtmlEntityService.Convert(10914, 824));
      HtmlEntityService.AddSingle(symbols, "NotNestedLessLess;", HtmlEntityService.Convert(10913, 824));
      HtmlEntityService.AddSingle(symbols, "NotPrecedes;", HtmlEntityService.Convert(8832));
      HtmlEntityService.AddSingle(symbols, "NotPrecedesEqual;", HtmlEntityService.Convert(10927, 824));
      HtmlEntityService.AddSingle(symbols, "NotPrecedesSlantEqual;", HtmlEntityService.Convert(8928));
      HtmlEntityService.AddSingle(symbols, "NotReverseElement;", HtmlEntityService.Convert(8716));
      HtmlEntityService.AddSingle(symbols, "NotRightTriangle;", HtmlEntityService.Convert(8939));
      HtmlEntityService.AddSingle(symbols, "NotRightTriangleBar;", HtmlEntityService.Convert(10704, 824));
      HtmlEntityService.AddSingle(symbols, "NotRightTriangleEqual;", HtmlEntityService.Convert(8941));
      HtmlEntityService.AddSingle(symbols, "NotSquareSubset;", HtmlEntityService.Convert(8847, 824));
      HtmlEntityService.AddSingle(symbols, "NotSquareSubsetEqual;", HtmlEntityService.Convert(8930));
      HtmlEntityService.AddSingle(symbols, "NotSquareSuperset;", HtmlEntityService.Convert(8848, 824));
      HtmlEntityService.AddSingle(symbols, "NotSquareSupersetEqual;", HtmlEntityService.Convert(8931));
      HtmlEntityService.AddSingle(symbols, "NotSubset;", HtmlEntityService.Convert(8834, 8402));
      HtmlEntityService.AddSingle(symbols, "NotSubsetEqual;", HtmlEntityService.Convert(8840));
      HtmlEntityService.AddSingle(symbols, "NotSucceeds;", HtmlEntityService.Convert(8833));
      HtmlEntityService.AddSingle(symbols, "NotSucceedsEqual;", HtmlEntityService.Convert(10928, 824));
      HtmlEntityService.AddSingle(symbols, "NotSucceedsSlantEqual;", HtmlEntityService.Convert(8929));
      HtmlEntityService.AddSingle(symbols, "NotSucceedsTilde;", HtmlEntityService.Convert(8831, 824));
      HtmlEntityService.AddSingle(symbols, "NotSuperset;", HtmlEntityService.Convert(8835, 8402));
      HtmlEntityService.AddSingle(symbols, "NotSupersetEqual;", HtmlEntityService.Convert(8841));
      HtmlEntityService.AddSingle(symbols, "NotTilde;", HtmlEntityService.Convert(8769));
      HtmlEntityService.AddSingle(symbols, "NotTildeEqual;", HtmlEntityService.Convert(8772));
      HtmlEntityService.AddSingle(symbols, "NotTildeFullEqual;", HtmlEntityService.Convert(8775));
      HtmlEntityService.AddSingle(symbols, "NotTildeTilde;", HtmlEntityService.Convert(8777));
      HtmlEntityService.AddSingle(symbols, "NotVerticalBar;", HtmlEntityService.Convert(8740));
      HtmlEntityService.AddSingle(symbols, "Nscr;", HtmlEntityService.Convert(119977));
      HtmlEntityService.AddBoth(symbols, "Ntilde;", HtmlEntityService.Convert(209));
      HtmlEntityService.AddSingle(symbols, "Nu;", HtmlEntityService.Convert(925));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleO()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddBoth(symbols, "oacute;", HtmlEntityService.Convert(243));
      HtmlEntityService.AddSingle(symbols, "oast;", HtmlEntityService.Convert(8859));
      HtmlEntityService.AddSingle(symbols, "ocir;", HtmlEntityService.Convert(8858));
      HtmlEntityService.AddBoth(symbols, "ocirc;", HtmlEntityService.Convert(244));
      HtmlEntityService.AddSingle(symbols, "ocy;", HtmlEntityService.Convert(1086));
      HtmlEntityService.AddSingle(symbols, "odash;", HtmlEntityService.Convert(8861));
      HtmlEntityService.AddSingle(symbols, "odblac;", HtmlEntityService.Convert(337));
      HtmlEntityService.AddSingle(symbols, "odiv;", HtmlEntityService.Convert(10808));
      HtmlEntityService.AddSingle(symbols, "odot;", HtmlEntityService.Convert(8857));
      HtmlEntityService.AddSingle(symbols, "odsold;", HtmlEntityService.Convert(10684));
      HtmlEntityService.AddSingle(symbols, "oelig;", HtmlEntityService.Convert(339));
      HtmlEntityService.AddSingle(symbols, "ofcir;", HtmlEntityService.Convert(10687));
      HtmlEntityService.AddSingle(symbols, "ofr;", HtmlEntityService.Convert(120108));
      HtmlEntityService.AddSingle(symbols, "ogon;", HtmlEntityService.Convert(731));
      HtmlEntityService.AddBoth(symbols, "ograve;", HtmlEntityService.Convert(242));
      HtmlEntityService.AddSingle(symbols, "ogt;", HtmlEntityService.Convert(10689));
      HtmlEntityService.AddSingle(symbols, "ohbar;", HtmlEntityService.Convert(10677));
      HtmlEntityService.AddSingle(symbols, "ohm;", HtmlEntityService.Convert(937));
      HtmlEntityService.AddSingle(symbols, "oint;", HtmlEntityService.Convert(8750));
      HtmlEntityService.AddSingle(symbols, "olarr;", HtmlEntityService.Convert(8634));
      HtmlEntityService.AddSingle(symbols, "olcir;", HtmlEntityService.Convert(10686));
      HtmlEntityService.AddSingle(symbols, "olcross;", HtmlEntityService.Convert(10683));
      HtmlEntityService.AddSingle(symbols, "oline;", HtmlEntityService.Convert(8254));
      HtmlEntityService.AddSingle(symbols, "olt;", HtmlEntityService.Convert(10688));
      HtmlEntityService.AddSingle(symbols, "omacr;", HtmlEntityService.Convert(333));
      HtmlEntityService.AddSingle(symbols, "omega;", HtmlEntityService.Convert(969));
      HtmlEntityService.AddSingle(symbols, "omicron;", HtmlEntityService.Convert(959));
      HtmlEntityService.AddSingle(symbols, "omid;", HtmlEntityService.Convert(10678));
      HtmlEntityService.AddSingle(symbols, "ominus;", HtmlEntityService.Convert(8854));
      HtmlEntityService.AddSingle(symbols, "oopf;", HtmlEntityService.Convert(120160));
      HtmlEntityService.AddSingle(symbols, "opar;", HtmlEntityService.Convert(10679));
      HtmlEntityService.AddSingle(symbols, "operp;", HtmlEntityService.Convert(10681));
      HtmlEntityService.AddSingle(symbols, "oplus;", HtmlEntityService.Convert(8853));
      HtmlEntityService.AddSingle(symbols, "or;", HtmlEntityService.Convert(8744));
      HtmlEntityService.AddSingle(symbols, "orarr;", HtmlEntityService.Convert(8635));
      HtmlEntityService.AddSingle(symbols, "ord;", HtmlEntityService.Convert(10845));
      HtmlEntityService.AddSingle(symbols, "order;", HtmlEntityService.Convert(8500));
      HtmlEntityService.AddSingle(symbols, "orderof;", HtmlEntityService.Convert(8500));
      HtmlEntityService.AddBoth(symbols, "ordf;", HtmlEntityService.Convert(170));
      HtmlEntityService.AddBoth(symbols, "ordm;", HtmlEntityService.Convert(186));
      HtmlEntityService.AddSingle(symbols, "origof;", HtmlEntityService.Convert(8886));
      HtmlEntityService.AddSingle(symbols, "oror;", HtmlEntityService.Convert(10838));
      HtmlEntityService.AddSingle(symbols, "orslope;", HtmlEntityService.Convert(10839));
      HtmlEntityService.AddSingle(symbols, "orv;", HtmlEntityService.Convert(10843));
      HtmlEntityService.AddSingle(symbols, "oS;", HtmlEntityService.Convert(9416));
      HtmlEntityService.AddSingle(symbols, "oscr;", HtmlEntityService.Convert(8500));
      HtmlEntityService.AddBoth(symbols, "oslash;", HtmlEntityService.Convert(248));
      HtmlEntityService.AddSingle(symbols, "osol;", HtmlEntityService.Convert(8856));
      HtmlEntityService.AddBoth(symbols, "otilde;", HtmlEntityService.Convert(245));
      HtmlEntityService.AddSingle(symbols, "otimes;", HtmlEntityService.Convert(8855));
      HtmlEntityService.AddSingle(symbols, "otimesas;", HtmlEntityService.Convert(10806));
      HtmlEntityService.AddBoth(symbols, "ouml;", HtmlEntityService.Convert(246));
      HtmlEntityService.AddSingle(symbols, "ovbar;", HtmlEntityService.Convert(9021));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigO()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddBoth(symbols, "Oacute;", HtmlEntityService.Convert(211));
      HtmlEntityService.AddBoth(symbols, "Ocirc;", HtmlEntityService.Convert(212));
      HtmlEntityService.AddSingle(symbols, "Ocy;", HtmlEntityService.Convert(1054));
      HtmlEntityService.AddSingle(symbols, "Odblac;", HtmlEntityService.Convert(336));
      HtmlEntityService.AddSingle(symbols, "OElig;", HtmlEntityService.Convert(338));
      HtmlEntityService.AddSingle(symbols, "Ofr;", HtmlEntityService.Convert(120082));
      HtmlEntityService.AddBoth(symbols, "Ograve;", HtmlEntityService.Convert(210));
      HtmlEntityService.AddSingle(symbols, "Omacr;", HtmlEntityService.Convert(332));
      HtmlEntityService.AddSingle(symbols, "Omega;", HtmlEntityService.Convert(937));
      HtmlEntityService.AddSingle(symbols, "Omicron;", HtmlEntityService.Convert(927));
      HtmlEntityService.AddSingle(symbols, "Oopf;", HtmlEntityService.Convert(120134));
      HtmlEntityService.AddSingle(symbols, "OpenCurlyDoubleQuote;", HtmlEntityService.Convert(8220));
      HtmlEntityService.AddSingle(symbols, "OpenCurlyQuote;", HtmlEntityService.Convert(8216));
      HtmlEntityService.AddSingle(symbols, "Or;", HtmlEntityService.Convert(10836));
      HtmlEntityService.AddSingle(symbols, "Oscr;", HtmlEntityService.Convert(119978));
      HtmlEntityService.AddBoth(symbols, "Oslash;", HtmlEntityService.Convert(216));
      HtmlEntityService.AddBoth(symbols, "Otilde;", HtmlEntityService.Convert(213));
      HtmlEntityService.AddSingle(symbols, "Otimes;", HtmlEntityService.Convert(10807));
      HtmlEntityService.AddBoth(symbols, "Ouml;", HtmlEntityService.Convert(214));
      HtmlEntityService.AddSingle(symbols, "OverBar;", HtmlEntityService.Convert(8254));
      HtmlEntityService.AddSingle(symbols, "OverBrace;", HtmlEntityService.Convert(9182));
      HtmlEntityService.AddSingle(symbols, "OverBracket;", HtmlEntityService.Convert(9140));
      HtmlEntityService.AddSingle(symbols, "OverParenthesis;", HtmlEntityService.Convert(9180));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleP()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "pfr;", HtmlEntityService.Convert(120109));
      HtmlEntityService.AddSingle(symbols, "par;", HtmlEntityService.Convert(8741));
      HtmlEntityService.AddBoth(symbols, "para;", HtmlEntityService.Convert(182));
      HtmlEntityService.AddSingle(symbols, "parallel;", HtmlEntityService.Convert(8741));
      HtmlEntityService.AddSingle(symbols, "parsim;", HtmlEntityService.Convert(10995));
      HtmlEntityService.AddSingle(symbols, "parsl;", HtmlEntityService.Convert(11005));
      HtmlEntityService.AddSingle(symbols, "part;", HtmlEntityService.Convert(8706));
      HtmlEntityService.AddSingle(symbols, "pcy;", HtmlEntityService.Convert(1087));
      HtmlEntityService.AddSingle(symbols, "percnt;", HtmlEntityService.Convert(37));
      HtmlEntityService.AddSingle(symbols, "period;", HtmlEntityService.Convert(46));
      HtmlEntityService.AddSingle(symbols, "permil;", HtmlEntityService.Convert(8240));
      HtmlEntityService.AddSingle(symbols, "perp;", HtmlEntityService.Convert(8869));
      HtmlEntityService.AddSingle(symbols, "pertenk;", HtmlEntityService.Convert(8241));
      HtmlEntityService.AddSingle(symbols, "phi;", HtmlEntityService.Convert(966));
      HtmlEntityService.AddSingle(symbols, "phiv;", HtmlEntityService.Convert(981));
      HtmlEntityService.AddSingle(symbols, "phmmat;", HtmlEntityService.Convert(8499));
      HtmlEntityService.AddSingle(symbols, "phone;", HtmlEntityService.Convert(9742));
      HtmlEntityService.AddSingle(symbols, "pi;", HtmlEntityService.Convert(960));
      HtmlEntityService.AddSingle(symbols, "pitchfork;", HtmlEntityService.Convert(8916));
      HtmlEntityService.AddSingle(symbols, "piv;", HtmlEntityService.Convert(982));
      HtmlEntityService.AddSingle(symbols, "planck;", HtmlEntityService.Convert(8463));
      HtmlEntityService.AddSingle(symbols, "planckh;", HtmlEntityService.Convert(8462));
      HtmlEntityService.AddSingle(symbols, "plankv;", HtmlEntityService.Convert(8463));
      HtmlEntityService.AddSingle(symbols, "plus;", HtmlEntityService.Convert(43));
      HtmlEntityService.AddSingle(symbols, "plusacir;", HtmlEntityService.Convert(10787));
      HtmlEntityService.AddSingle(symbols, "plusb;", HtmlEntityService.Convert(8862));
      HtmlEntityService.AddSingle(symbols, "pluscir;", HtmlEntityService.Convert(10786));
      HtmlEntityService.AddSingle(symbols, "plusdo;", HtmlEntityService.Convert(8724));
      HtmlEntityService.AddSingle(symbols, "plusdu;", HtmlEntityService.Convert(10789));
      HtmlEntityService.AddSingle(symbols, "pluse;", HtmlEntityService.Convert(10866));
      HtmlEntityService.AddBoth(symbols, "plusmn;", HtmlEntityService.Convert(177));
      HtmlEntityService.AddSingle(symbols, "plussim;", HtmlEntityService.Convert(10790));
      HtmlEntityService.AddSingle(symbols, "plustwo;", HtmlEntityService.Convert(10791));
      HtmlEntityService.AddSingle(symbols, "pm;", HtmlEntityService.Convert(177));
      HtmlEntityService.AddSingle(symbols, "pointint;", HtmlEntityService.Convert(10773));
      HtmlEntityService.AddSingle(symbols, "popf;", HtmlEntityService.Convert(120161));
      HtmlEntityService.AddBoth(symbols, "pound;", HtmlEntityService.Convert(163));
      HtmlEntityService.AddSingle(symbols, "pr;", HtmlEntityService.Convert(8826));
      HtmlEntityService.AddSingle(symbols, "prap;", HtmlEntityService.Convert(10935));
      HtmlEntityService.AddSingle(symbols, "prcue;", HtmlEntityService.Convert(8828));
      HtmlEntityService.AddSingle(symbols, "prE;", HtmlEntityService.Convert(10931));
      HtmlEntityService.AddSingle(symbols, "pre;", HtmlEntityService.Convert(10927));
      HtmlEntityService.AddSingle(symbols, "prec;", HtmlEntityService.Convert(8826));
      HtmlEntityService.AddSingle(symbols, "precapprox;", HtmlEntityService.Convert(10935));
      HtmlEntityService.AddSingle(symbols, "preccurlyeq;", HtmlEntityService.Convert(8828));
      HtmlEntityService.AddSingle(symbols, "preceq;", HtmlEntityService.Convert(10927));
      HtmlEntityService.AddSingle(symbols, "precnapprox;", HtmlEntityService.Convert(10937));
      HtmlEntityService.AddSingle(symbols, "precneqq;", HtmlEntityService.Convert(10933));
      HtmlEntityService.AddSingle(symbols, "precnsim;", HtmlEntityService.Convert(8936));
      HtmlEntityService.AddSingle(symbols, "precsim;", HtmlEntityService.Convert(8830));
      HtmlEntityService.AddSingle(symbols, "prime;", HtmlEntityService.Convert(8242));
      HtmlEntityService.AddSingle(symbols, "primes;", HtmlEntityService.Convert(8473));
      HtmlEntityService.AddSingle(symbols, "prnap;", HtmlEntityService.Convert(10937));
      HtmlEntityService.AddSingle(symbols, "prnE;", HtmlEntityService.Convert(10933));
      HtmlEntityService.AddSingle(symbols, "prnsim;", HtmlEntityService.Convert(8936));
      HtmlEntityService.AddSingle(symbols, "prod;", HtmlEntityService.Convert(8719));
      HtmlEntityService.AddSingle(symbols, "profalar;", HtmlEntityService.Convert(9006));
      HtmlEntityService.AddSingle(symbols, "profline;", HtmlEntityService.Convert(8978));
      HtmlEntityService.AddSingle(symbols, "profsurf;", HtmlEntityService.Convert(8979));
      HtmlEntityService.AddSingle(symbols, "prop;", HtmlEntityService.Convert(8733));
      HtmlEntityService.AddSingle(symbols, "propto;", HtmlEntityService.Convert(8733));
      HtmlEntityService.AddSingle(symbols, "prsim;", HtmlEntityService.Convert(8830));
      HtmlEntityService.AddSingle(symbols, "prurel;", HtmlEntityService.Convert(8880));
      HtmlEntityService.AddSingle(symbols, "pscr;", HtmlEntityService.Convert(120005));
      HtmlEntityService.AddSingle(symbols, "psi;", HtmlEntityService.Convert(968));
      HtmlEntityService.AddSingle(symbols, "puncsp;", HtmlEntityService.Convert(8200));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigP()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "PartialD;", HtmlEntityService.Convert(8706));
      HtmlEntityService.AddSingle(symbols, "Pcy;", HtmlEntityService.Convert(1055));
      HtmlEntityService.AddSingle(symbols, "Pfr;", HtmlEntityService.Convert(120083));
      HtmlEntityService.AddSingle(symbols, "Phi;", HtmlEntityService.Convert(934));
      HtmlEntityService.AddSingle(symbols, "Pi;", HtmlEntityService.Convert(928));
      HtmlEntityService.AddSingle(symbols, "PlusMinus;", HtmlEntityService.Convert(177));
      HtmlEntityService.AddSingle(symbols, "Poincareplane;", HtmlEntityService.Convert(8460));
      HtmlEntityService.AddSingle(symbols, "Popf;", HtmlEntityService.Convert(8473));
      HtmlEntityService.AddSingle(symbols, "Pr;", HtmlEntityService.Convert(10939));
      HtmlEntityService.AddSingle(symbols, "Precedes;", HtmlEntityService.Convert(8826));
      HtmlEntityService.AddSingle(symbols, "PrecedesEqual;", HtmlEntityService.Convert(10927));
      HtmlEntityService.AddSingle(symbols, "PrecedesSlantEqual;", HtmlEntityService.Convert(8828));
      HtmlEntityService.AddSingle(symbols, "PrecedesTilde;", HtmlEntityService.Convert(8830));
      HtmlEntityService.AddSingle(symbols, "Prime;", HtmlEntityService.Convert(8243));
      HtmlEntityService.AddSingle(symbols, "Product;", HtmlEntityService.Convert(8719));
      HtmlEntityService.AddSingle(symbols, "Proportion;", HtmlEntityService.Convert(8759));
      HtmlEntityService.AddSingle(symbols, "Proportional;", HtmlEntityService.Convert(8733));
      HtmlEntityService.AddSingle(symbols, "Pscr;", HtmlEntityService.Convert(119979));
      HtmlEntityService.AddSingle(symbols, "Psi;", HtmlEntityService.Convert(936));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleQ()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "qfr;", HtmlEntityService.Convert(120110));
      HtmlEntityService.AddSingle(symbols, "qint;", HtmlEntityService.Convert(10764));
      HtmlEntityService.AddSingle(symbols, "qopf;", HtmlEntityService.Convert(120162));
      HtmlEntityService.AddSingle(symbols, "qprime;", HtmlEntityService.Convert(8279));
      HtmlEntityService.AddSingle(symbols, "qscr;", HtmlEntityService.Convert(120006));
      HtmlEntityService.AddSingle(symbols, "quaternions;", HtmlEntityService.Convert(8461));
      HtmlEntityService.AddSingle(symbols, "quatint;", HtmlEntityService.Convert(10774));
      HtmlEntityService.AddSingle(symbols, "quest;", HtmlEntityService.Convert(63));
      HtmlEntityService.AddSingle(symbols, "questeq;", HtmlEntityService.Convert(8799));
      HtmlEntityService.AddBoth(symbols, "quot;", HtmlEntityService.Convert(34));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigQ()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Qfr;", HtmlEntityService.Convert(120084));
      HtmlEntityService.AddSingle(symbols, "Qopf;", HtmlEntityService.Convert(8474));
      HtmlEntityService.AddSingle(symbols, "Qscr;", HtmlEntityService.Convert(119980));
      HtmlEntityService.AddBoth(symbols, "QUOT;", HtmlEntityService.Convert(34));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleR()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "rAarr;", HtmlEntityService.Convert(8667));
      HtmlEntityService.AddSingle(symbols, "race;", HtmlEntityService.Convert(8765, 817));
      HtmlEntityService.AddSingle(symbols, "racute;", HtmlEntityService.Convert(341));
      HtmlEntityService.AddSingle(symbols, "radic;", HtmlEntityService.Convert(8730));
      HtmlEntityService.AddSingle(symbols, "raemptyv;", HtmlEntityService.Convert(10675));
      HtmlEntityService.AddSingle(symbols, "rang;", HtmlEntityService.Convert(10217));
      HtmlEntityService.AddSingle(symbols, "rangd;", HtmlEntityService.Convert(10642));
      HtmlEntityService.AddSingle(symbols, "range;", HtmlEntityService.Convert(10661));
      HtmlEntityService.AddSingle(symbols, "rangle;", HtmlEntityService.Convert(10217));
      HtmlEntityService.AddBoth(symbols, "raquo;", HtmlEntityService.Convert(187));
      HtmlEntityService.AddSingle(symbols, "rArr;", HtmlEntityService.Convert(8658));
      HtmlEntityService.AddSingle(symbols, "rarr;", HtmlEntityService.Convert(8594));
      HtmlEntityService.AddSingle(symbols, "rarrap;", HtmlEntityService.Convert(10613));
      HtmlEntityService.AddSingle(symbols, "rarrb;", HtmlEntityService.Convert(8677));
      HtmlEntityService.AddSingle(symbols, "rarrbfs;", HtmlEntityService.Convert(10528));
      HtmlEntityService.AddSingle(symbols, "rarrc;", HtmlEntityService.Convert(10547));
      HtmlEntityService.AddSingle(symbols, "rarrfs;", HtmlEntityService.Convert(10526));
      HtmlEntityService.AddSingle(symbols, "rarrhk;", HtmlEntityService.Convert(8618));
      HtmlEntityService.AddSingle(symbols, "rarrlp;", HtmlEntityService.Convert(8620));
      HtmlEntityService.AddSingle(symbols, "rarrpl;", HtmlEntityService.Convert(10565));
      HtmlEntityService.AddSingle(symbols, "rarrsim;", HtmlEntityService.Convert(10612));
      HtmlEntityService.AddSingle(symbols, "rarrtl;", HtmlEntityService.Convert(8611));
      HtmlEntityService.AddSingle(symbols, "rarrw;", HtmlEntityService.Convert(8605));
      HtmlEntityService.AddSingle(symbols, "rAtail;", HtmlEntityService.Convert(10524));
      HtmlEntityService.AddSingle(symbols, "ratail;", HtmlEntityService.Convert(10522));
      HtmlEntityService.AddSingle(symbols, "ratio;", HtmlEntityService.Convert(8758));
      HtmlEntityService.AddSingle(symbols, "rationals;", HtmlEntityService.Convert(8474));
      HtmlEntityService.AddSingle(symbols, "rBarr;", HtmlEntityService.Convert(10511));
      HtmlEntityService.AddSingle(symbols, "rbarr;", HtmlEntityService.Convert(10509));
      HtmlEntityService.AddSingle(symbols, "rbbrk;", HtmlEntityService.Convert(10099));
      HtmlEntityService.AddSingle(symbols, "rbrace;", HtmlEntityService.Convert(125));
      HtmlEntityService.AddSingle(symbols, "rbrack;", HtmlEntityService.Convert(93));
      HtmlEntityService.AddSingle(symbols, "rbrke;", HtmlEntityService.Convert(10636));
      HtmlEntityService.AddSingle(symbols, "rbrksld;", HtmlEntityService.Convert(10638));
      HtmlEntityService.AddSingle(symbols, "rbrkslu;", HtmlEntityService.Convert(10640));
      HtmlEntityService.AddSingle(symbols, "rcaron;", HtmlEntityService.Convert(345));
      HtmlEntityService.AddSingle(symbols, "rcedil;", HtmlEntityService.Convert(343));
      HtmlEntityService.AddSingle(symbols, "rceil;", HtmlEntityService.Convert(8969));
      HtmlEntityService.AddSingle(symbols, "rcub;", HtmlEntityService.Convert(125));
      HtmlEntityService.AddSingle(symbols, "rcy;", HtmlEntityService.Convert(1088));
      HtmlEntityService.AddSingle(symbols, "rdca;", HtmlEntityService.Convert(10551));
      HtmlEntityService.AddSingle(symbols, "rdldhar;", HtmlEntityService.Convert(10601));
      HtmlEntityService.AddSingle(symbols, "rdquo;", HtmlEntityService.Convert(8221));
      HtmlEntityService.AddSingle(symbols, "rdquor;", HtmlEntityService.Convert(8221));
      HtmlEntityService.AddSingle(symbols, "rdsh;", HtmlEntityService.Convert(8627));
      HtmlEntityService.AddSingle(symbols, "real;", HtmlEntityService.Convert(8476));
      HtmlEntityService.AddSingle(symbols, "realine;", HtmlEntityService.Convert(8475));
      HtmlEntityService.AddSingle(symbols, "realpart;", HtmlEntityService.Convert(8476));
      HtmlEntityService.AddSingle(symbols, "reals;", HtmlEntityService.Convert(8477));
      HtmlEntityService.AddSingle(symbols, "rect;", HtmlEntityService.Convert(9645));
      HtmlEntityService.AddBoth(symbols, "reg;", HtmlEntityService.Convert(174));
      HtmlEntityService.AddSingle(symbols, "rfisht;", HtmlEntityService.Convert(10621));
      HtmlEntityService.AddSingle(symbols, "rfloor;", HtmlEntityService.Convert(8971));
      HtmlEntityService.AddSingle(symbols, "rfr;", HtmlEntityService.Convert(120111));
      HtmlEntityService.AddSingle(symbols, "rHar;", HtmlEntityService.Convert(10596));
      HtmlEntityService.AddSingle(symbols, "rhard;", HtmlEntityService.Convert(8641));
      HtmlEntityService.AddSingle(symbols, "rharu;", HtmlEntityService.Convert(8640));
      HtmlEntityService.AddSingle(symbols, "rharul;", HtmlEntityService.Convert(10604));
      HtmlEntityService.AddSingle(symbols, "rho;", HtmlEntityService.Convert(961));
      HtmlEntityService.AddSingle(symbols, "rhov;", HtmlEntityService.Convert(1009));
      HtmlEntityService.AddSingle(symbols, "rightarrow;", HtmlEntityService.Convert(8594));
      HtmlEntityService.AddSingle(symbols, "rightarrowtail;", HtmlEntityService.Convert(8611));
      HtmlEntityService.AddSingle(symbols, "rightharpoondown;", HtmlEntityService.Convert(8641));
      HtmlEntityService.AddSingle(symbols, "rightharpoonup;", HtmlEntityService.Convert(8640));
      HtmlEntityService.AddSingle(symbols, "rightleftarrows;", HtmlEntityService.Convert(8644));
      HtmlEntityService.AddSingle(symbols, "rightleftharpoons;", HtmlEntityService.Convert(8652));
      HtmlEntityService.AddSingle(symbols, "rightrightarrows;", HtmlEntityService.Convert(8649));
      HtmlEntityService.AddSingle(symbols, "rightsquigarrow;", HtmlEntityService.Convert(8605));
      HtmlEntityService.AddSingle(symbols, "rightthreetimes;", HtmlEntityService.Convert(8908));
      HtmlEntityService.AddSingle(symbols, "ring;", HtmlEntityService.Convert(730));
      HtmlEntityService.AddSingle(symbols, "risingdotseq;", HtmlEntityService.Convert(8787));
      HtmlEntityService.AddSingle(symbols, "rlarr;", HtmlEntityService.Convert(8644));
      HtmlEntityService.AddSingle(symbols, "rlhar;", HtmlEntityService.Convert(8652));
      HtmlEntityService.AddSingle(symbols, "rlm;", HtmlEntityService.Convert(8207));
      HtmlEntityService.AddSingle(symbols, "rmoust;", HtmlEntityService.Convert(9137));
      HtmlEntityService.AddSingle(symbols, "rmoustache;", HtmlEntityService.Convert(9137));
      HtmlEntityService.AddSingle(symbols, "rnmid;", HtmlEntityService.Convert(10990));
      HtmlEntityService.AddSingle(symbols, "roang;", HtmlEntityService.Convert(10221));
      HtmlEntityService.AddSingle(symbols, "roarr;", HtmlEntityService.Convert(8702));
      HtmlEntityService.AddSingle(symbols, "robrk;", HtmlEntityService.Convert(10215));
      HtmlEntityService.AddSingle(symbols, "ropar;", HtmlEntityService.Convert(10630));
      HtmlEntityService.AddSingle(symbols, "ropf;", HtmlEntityService.Convert(120163));
      HtmlEntityService.AddSingle(symbols, "roplus;", HtmlEntityService.Convert(10798));
      HtmlEntityService.AddSingle(symbols, "rotimes;", HtmlEntityService.Convert(10805));
      HtmlEntityService.AddSingle(symbols, "rpar;", HtmlEntityService.Convert(41));
      HtmlEntityService.AddSingle(symbols, "rpargt;", HtmlEntityService.Convert(10644));
      HtmlEntityService.AddSingle(symbols, "rppolint;", HtmlEntityService.Convert(10770));
      HtmlEntityService.AddSingle(symbols, "rrarr;", HtmlEntityService.Convert(8649));
      HtmlEntityService.AddSingle(symbols, "rsaquo;", HtmlEntityService.Convert(8250));
      HtmlEntityService.AddSingle(symbols, "rscr;", HtmlEntityService.Convert(120007));
      HtmlEntityService.AddSingle(symbols, "rsh;", HtmlEntityService.Convert(8625));
      HtmlEntityService.AddSingle(symbols, "rsqb;", HtmlEntityService.Convert(93));
      HtmlEntityService.AddSingle(symbols, "rsquo;", HtmlEntityService.Convert(8217));
      HtmlEntityService.AddSingle(symbols, "rsquor;", HtmlEntityService.Convert(8217));
      HtmlEntityService.AddSingle(symbols, "rthree;", HtmlEntityService.Convert(8908));
      HtmlEntityService.AddSingle(symbols, "rtimes;", HtmlEntityService.Convert(8906));
      HtmlEntityService.AddSingle(symbols, "rtri;", HtmlEntityService.Convert(9657));
      HtmlEntityService.AddSingle(symbols, "rtrie;", HtmlEntityService.Convert(8885));
      HtmlEntityService.AddSingle(symbols, "rtrif;", HtmlEntityService.Convert(9656));
      HtmlEntityService.AddSingle(symbols, "rtriltri;", HtmlEntityService.Convert(10702));
      HtmlEntityService.AddSingle(symbols, "ruluhar;", HtmlEntityService.Convert(10600));
      HtmlEntityService.AddSingle(symbols, "rx;", HtmlEntityService.Convert(8478));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigR()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Racute;", HtmlEntityService.Convert(340));
      HtmlEntityService.AddSingle(symbols, "Rang;", HtmlEntityService.Convert(10219));
      HtmlEntityService.AddSingle(symbols, "Rarr;", HtmlEntityService.Convert(8608));
      HtmlEntityService.AddSingle(symbols, "Rarrtl;", HtmlEntityService.Convert(10518));
      HtmlEntityService.AddSingle(symbols, "RBarr;", HtmlEntityService.Convert(10512));
      HtmlEntityService.AddSingle(symbols, "Rcaron;", HtmlEntityService.Convert(344));
      HtmlEntityService.AddSingle(symbols, "Rcedil;", HtmlEntityService.Convert(342));
      HtmlEntityService.AddSingle(symbols, "Rcy;", HtmlEntityService.Convert(1056));
      HtmlEntityService.AddSingle(symbols, "Re;", HtmlEntityService.Convert(8476));
      HtmlEntityService.AddBoth(symbols, "REG;", HtmlEntityService.Convert(174));
      HtmlEntityService.AddSingle(symbols, "ReverseElement;", HtmlEntityService.Convert(8715));
      HtmlEntityService.AddSingle(symbols, "ReverseEquilibrium;", HtmlEntityService.Convert(8651));
      HtmlEntityService.AddSingle(symbols, "ReverseUpEquilibrium;", HtmlEntityService.Convert(10607));
      HtmlEntityService.AddSingle(symbols, "Rfr;", HtmlEntityService.Convert(8476));
      HtmlEntityService.AddSingle(symbols, "Rho;", HtmlEntityService.Convert(929));
      HtmlEntityService.AddSingle(symbols, "RightAngleBracket;", HtmlEntityService.Convert(10217));
      HtmlEntityService.AddSingle(symbols, "RightArrow;", HtmlEntityService.Convert(8594));
      HtmlEntityService.AddSingle(symbols, "Rightarrow;", HtmlEntityService.Convert(8658));
      HtmlEntityService.AddSingle(symbols, "RightArrowBar;", HtmlEntityService.Convert(8677));
      HtmlEntityService.AddSingle(symbols, "RightArrowLeftArrow;", HtmlEntityService.Convert(8644));
      HtmlEntityService.AddSingle(symbols, "RightCeiling;", HtmlEntityService.Convert(8969));
      HtmlEntityService.AddSingle(symbols, "RightDoubleBracket;", HtmlEntityService.Convert(10215));
      HtmlEntityService.AddSingle(symbols, "RightDownTeeVector;", HtmlEntityService.Convert(10589));
      HtmlEntityService.AddSingle(symbols, "RightDownVector;", HtmlEntityService.Convert(8642));
      HtmlEntityService.AddSingle(symbols, "RightDownVectorBar;", HtmlEntityService.Convert(10581));
      HtmlEntityService.AddSingle(symbols, "RightFloor;", HtmlEntityService.Convert(8971));
      HtmlEntityService.AddSingle(symbols, "RightTee;", HtmlEntityService.Convert(8866));
      HtmlEntityService.AddSingle(symbols, "RightTeeArrow;", HtmlEntityService.Convert(8614));
      HtmlEntityService.AddSingle(symbols, "RightTeeVector;", HtmlEntityService.Convert(10587));
      HtmlEntityService.AddSingle(symbols, "RightTriangle;", HtmlEntityService.Convert(8883));
      HtmlEntityService.AddSingle(symbols, "RightTriangleBar;", HtmlEntityService.Convert(10704));
      HtmlEntityService.AddSingle(symbols, "RightTriangleEqual;", HtmlEntityService.Convert(8885));
      HtmlEntityService.AddSingle(symbols, "RightUpDownVector;", HtmlEntityService.Convert(10575));
      HtmlEntityService.AddSingle(symbols, "RightUpTeeVector;", HtmlEntityService.Convert(10588));
      HtmlEntityService.AddSingle(symbols, "RightUpVector;", HtmlEntityService.Convert(8638));
      HtmlEntityService.AddSingle(symbols, "RightUpVectorBar;", HtmlEntityService.Convert(10580));
      HtmlEntityService.AddSingle(symbols, "RightVector;", HtmlEntityService.Convert(8640));
      HtmlEntityService.AddSingle(symbols, "RightVectorBar;", HtmlEntityService.Convert(10579));
      HtmlEntityService.AddSingle(symbols, "Ropf;", HtmlEntityService.Convert(8477));
      HtmlEntityService.AddSingle(symbols, "RoundImplies;", HtmlEntityService.Convert(10608));
      HtmlEntityService.AddSingle(symbols, "Rrightarrow;", HtmlEntityService.Convert(8667));
      HtmlEntityService.AddSingle(symbols, "Rscr;", HtmlEntityService.Convert(8475));
      HtmlEntityService.AddSingle(symbols, "Rsh;", HtmlEntityService.Convert(8625));
      HtmlEntityService.AddSingle(symbols, "RuleDelayed;", HtmlEntityService.Convert(10740));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleS()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "sacute;", HtmlEntityService.Convert(347));
      HtmlEntityService.AddSingle(symbols, "sbquo;", HtmlEntityService.Convert(8218));
      HtmlEntityService.AddSingle(symbols, "sc;", HtmlEntityService.Convert(8827));
      HtmlEntityService.AddSingle(symbols, "scap;", HtmlEntityService.Convert(10936));
      HtmlEntityService.AddSingle(symbols, "scaron;", HtmlEntityService.Convert(353));
      HtmlEntityService.AddSingle(symbols, "sccue;", HtmlEntityService.Convert(8829));
      HtmlEntityService.AddSingle(symbols, "scE;", HtmlEntityService.Convert(10932));
      HtmlEntityService.AddSingle(symbols, "sce;", HtmlEntityService.Convert(10928));
      HtmlEntityService.AddSingle(symbols, "scedil;", HtmlEntityService.Convert(351));
      HtmlEntityService.AddSingle(symbols, "scirc;", HtmlEntityService.Convert(349));
      HtmlEntityService.AddSingle(symbols, "scnap;", HtmlEntityService.Convert(10938));
      HtmlEntityService.AddSingle(symbols, "scnE;", HtmlEntityService.Convert(10934));
      HtmlEntityService.AddSingle(symbols, "scnsim;", HtmlEntityService.Convert(8937));
      HtmlEntityService.AddSingle(symbols, "scpolint;", HtmlEntityService.Convert(10771));
      HtmlEntityService.AddSingle(symbols, "scsim;", HtmlEntityService.Convert(8831));
      HtmlEntityService.AddSingle(symbols, "scy;", HtmlEntityService.Convert(1089));
      HtmlEntityService.AddSingle(symbols, "sdot;", HtmlEntityService.Convert(8901));
      HtmlEntityService.AddSingle(symbols, "sdotb;", HtmlEntityService.Convert(8865));
      HtmlEntityService.AddSingle(symbols, "sdote;", HtmlEntityService.Convert(10854));
      HtmlEntityService.AddSingle(symbols, "searhk;", HtmlEntityService.Convert(10533));
      HtmlEntityService.AddSingle(symbols, "seArr;", HtmlEntityService.Convert(8664));
      HtmlEntityService.AddSingle(symbols, "searr;", HtmlEntityService.Convert(8600));
      HtmlEntityService.AddSingle(symbols, "searrow;", HtmlEntityService.Convert(8600));
      HtmlEntityService.AddBoth(symbols, "sect;", HtmlEntityService.Convert(167));
      HtmlEntityService.AddSingle(symbols, "semi;", HtmlEntityService.Convert(59));
      HtmlEntityService.AddSingle(symbols, "seswar;", HtmlEntityService.Convert(10537));
      HtmlEntityService.AddSingle(symbols, "setminus;", HtmlEntityService.Convert(8726));
      HtmlEntityService.AddSingle(symbols, "setmn;", HtmlEntityService.Convert(8726));
      HtmlEntityService.AddSingle(symbols, "sext;", HtmlEntityService.Convert(10038));
      HtmlEntityService.AddSingle(symbols, "sfr;", HtmlEntityService.Convert(120112));
      HtmlEntityService.AddSingle(symbols, "sfrown;", HtmlEntityService.Convert(8994));
      HtmlEntityService.AddSingle(symbols, "sharp;", HtmlEntityService.Convert(9839));
      HtmlEntityService.AddSingle(symbols, "shchcy;", HtmlEntityService.Convert(1097));
      HtmlEntityService.AddSingle(symbols, "shcy;", HtmlEntityService.Convert(1096));
      HtmlEntityService.AddSingle(symbols, "shortmid;", HtmlEntityService.Convert(8739));
      HtmlEntityService.AddSingle(symbols, "shortparallel;", HtmlEntityService.Convert(8741));
      HtmlEntityService.AddBoth(symbols, "shy;", HtmlEntityService.Convert(173));
      HtmlEntityService.AddSingle(symbols, "sigma;", HtmlEntityService.Convert(963));
      HtmlEntityService.AddSingle(symbols, "sigmaf;", HtmlEntityService.Convert(962));
      HtmlEntityService.AddSingle(symbols, "sigmav;", HtmlEntityService.Convert(962));
      HtmlEntityService.AddSingle(symbols, "sim;", HtmlEntityService.Convert(8764));
      HtmlEntityService.AddSingle(symbols, "simdot;", HtmlEntityService.Convert(10858));
      HtmlEntityService.AddSingle(symbols, "sime;", HtmlEntityService.Convert(8771));
      HtmlEntityService.AddSingle(symbols, "simeq;", HtmlEntityService.Convert(8771));
      HtmlEntityService.AddSingle(symbols, "simg;", HtmlEntityService.Convert(10910));
      HtmlEntityService.AddSingle(symbols, "simgE;", HtmlEntityService.Convert(10912));
      HtmlEntityService.AddSingle(symbols, "siml;", HtmlEntityService.Convert(10909));
      HtmlEntityService.AddSingle(symbols, "simlE;", HtmlEntityService.Convert(10911));
      HtmlEntityService.AddSingle(symbols, "simne;", HtmlEntityService.Convert(8774));
      HtmlEntityService.AddSingle(symbols, "simplus;", HtmlEntityService.Convert(10788));
      HtmlEntityService.AddSingle(symbols, "simrarr;", HtmlEntityService.Convert(10610));
      HtmlEntityService.AddSingle(symbols, "slarr;", HtmlEntityService.Convert(8592));
      HtmlEntityService.AddSingle(symbols, "smallsetminus;", HtmlEntityService.Convert(8726));
      HtmlEntityService.AddSingle(symbols, "smashp;", HtmlEntityService.Convert(10803));
      HtmlEntityService.AddSingle(symbols, "smeparsl;", HtmlEntityService.Convert(10724));
      HtmlEntityService.AddSingle(symbols, "smid;", HtmlEntityService.Convert(8739));
      HtmlEntityService.AddSingle(symbols, "smile;", HtmlEntityService.Convert(8995));
      HtmlEntityService.AddSingle(symbols, "smt;", HtmlEntityService.Convert(10922));
      HtmlEntityService.AddSingle(symbols, "smte;", HtmlEntityService.Convert(10924));
      HtmlEntityService.AddSingle(symbols, "smtes;", HtmlEntityService.Convert(10924, 65024));
      HtmlEntityService.AddSingle(symbols, "softcy;", HtmlEntityService.Convert(1100));
      HtmlEntityService.AddSingle(symbols, "sol;", HtmlEntityService.Convert(47));
      HtmlEntityService.AddSingle(symbols, "solb;", HtmlEntityService.Convert(10692));
      HtmlEntityService.AddSingle(symbols, "solbar;", HtmlEntityService.Convert(9023));
      HtmlEntityService.AddSingle(symbols, "sopf;", HtmlEntityService.Convert(120164));
      HtmlEntityService.AddSingle(symbols, "spades;", HtmlEntityService.Convert(9824));
      HtmlEntityService.AddSingle(symbols, "spadesuit;", HtmlEntityService.Convert(9824));
      HtmlEntityService.AddSingle(symbols, "spar;", HtmlEntityService.Convert(8741));
      HtmlEntityService.AddSingle(symbols, "sqcap;", HtmlEntityService.Convert(8851));
      HtmlEntityService.AddSingle(symbols, "sqcaps;", HtmlEntityService.Convert(8851, 65024));
      HtmlEntityService.AddSingle(symbols, "sqcup;", HtmlEntityService.Convert(8852));
      HtmlEntityService.AddSingle(symbols, "sqcups;", HtmlEntityService.Convert(8852, 65024));
      HtmlEntityService.AddSingle(symbols, "sqsub;", HtmlEntityService.Convert(8847));
      HtmlEntityService.AddSingle(symbols, "sqsube;", HtmlEntityService.Convert(8849));
      HtmlEntityService.AddSingle(symbols, "sqsubset;", HtmlEntityService.Convert(8847));
      HtmlEntityService.AddSingle(symbols, "sqsubseteq;", HtmlEntityService.Convert(8849));
      HtmlEntityService.AddSingle(symbols, "sqsup;", HtmlEntityService.Convert(8848));
      HtmlEntityService.AddSingle(symbols, "sqsupe;", HtmlEntityService.Convert(8850));
      HtmlEntityService.AddSingle(symbols, "sqsupset;", HtmlEntityService.Convert(8848));
      HtmlEntityService.AddSingle(symbols, "sqsupseteq;", HtmlEntityService.Convert(8850));
      HtmlEntityService.AddSingle(symbols, "squ;", HtmlEntityService.Convert(9633));
      HtmlEntityService.AddSingle(symbols, "square;", HtmlEntityService.Convert(9633));
      HtmlEntityService.AddSingle(symbols, "squarf;", HtmlEntityService.Convert(9642));
      HtmlEntityService.AddSingle(symbols, "squf;", HtmlEntityService.Convert(9642));
      HtmlEntityService.AddSingle(symbols, "srarr;", HtmlEntityService.Convert(8594));
      HtmlEntityService.AddSingle(symbols, "sscr;", HtmlEntityService.Convert(120008));
      HtmlEntityService.AddSingle(symbols, "ssetmn;", HtmlEntityService.Convert(8726));
      HtmlEntityService.AddSingle(symbols, "ssmile;", HtmlEntityService.Convert(8995));
      HtmlEntityService.AddSingle(symbols, "sstarf;", HtmlEntityService.Convert(8902));
      HtmlEntityService.AddSingle(symbols, "star;", HtmlEntityService.Convert(9734));
      HtmlEntityService.AddSingle(symbols, "starf;", HtmlEntityService.Convert(9733));
      HtmlEntityService.AddSingle(symbols, "straightepsilon;", HtmlEntityService.Convert(1013));
      HtmlEntityService.AddSingle(symbols, "straightphi;", HtmlEntityService.Convert(981));
      HtmlEntityService.AddSingle(symbols, "strns;", HtmlEntityService.Convert(175));
      HtmlEntityService.AddSingle(symbols, "sub;", HtmlEntityService.Convert(8834));
      HtmlEntityService.AddSingle(symbols, "subdot;", HtmlEntityService.Convert(10941));
      HtmlEntityService.AddSingle(symbols, "subE;", HtmlEntityService.Convert(10949));
      HtmlEntityService.AddSingle(symbols, "sube;", HtmlEntityService.Convert(8838));
      HtmlEntityService.AddSingle(symbols, "subedot;", HtmlEntityService.Convert(10947));
      HtmlEntityService.AddSingle(symbols, "submult;", HtmlEntityService.Convert(10945));
      HtmlEntityService.AddSingle(symbols, "subnE;", HtmlEntityService.Convert(10955));
      HtmlEntityService.AddSingle(symbols, "subne;", HtmlEntityService.Convert(8842));
      HtmlEntityService.AddSingle(symbols, "subplus;", HtmlEntityService.Convert(10943));
      HtmlEntityService.AddSingle(symbols, "subrarr;", HtmlEntityService.Convert(10617));
      HtmlEntityService.AddSingle(symbols, "subset;", HtmlEntityService.Convert(8834));
      HtmlEntityService.AddSingle(symbols, "subseteq;", HtmlEntityService.Convert(8838));
      HtmlEntityService.AddSingle(symbols, "subseteqq;", HtmlEntityService.Convert(10949));
      HtmlEntityService.AddSingle(symbols, "subsetneq;", HtmlEntityService.Convert(8842));
      HtmlEntityService.AddSingle(symbols, "subsetneqq;", HtmlEntityService.Convert(10955));
      HtmlEntityService.AddSingle(symbols, "subsim;", HtmlEntityService.Convert(10951));
      HtmlEntityService.AddSingle(symbols, "subsub;", HtmlEntityService.Convert(10965));
      HtmlEntityService.AddSingle(symbols, "subsup;", HtmlEntityService.Convert(10963));
      HtmlEntityService.AddSingle(symbols, "succ;", HtmlEntityService.Convert(8827));
      HtmlEntityService.AddSingle(symbols, "succapprox;", HtmlEntityService.Convert(10936));
      HtmlEntityService.AddSingle(symbols, "succcurlyeq;", HtmlEntityService.Convert(8829));
      HtmlEntityService.AddSingle(symbols, "succeq;", HtmlEntityService.Convert(10928));
      HtmlEntityService.AddSingle(symbols, "succnapprox;", HtmlEntityService.Convert(10938));
      HtmlEntityService.AddSingle(symbols, "succneqq;", HtmlEntityService.Convert(10934));
      HtmlEntityService.AddSingle(symbols, "succnsim;", HtmlEntityService.Convert(8937));
      HtmlEntityService.AddSingle(symbols, "succsim;", HtmlEntityService.Convert(8831));
      HtmlEntityService.AddSingle(symbols, "sum;", HtmlEntityService.Convert(8721));
      HtmlEntityService.AddSingle(symbols, "sung;", HtmlEntityService.Convert(9834));
      HtmlEntityService.AddSingle(symbols, "sup;", HtmlEntityService.Convert(8835));
      HtmlEntityService.AddBoth(symbols, "sup1;", HtmlEntityService.Convert(185));
      HtmlEntityService.AddBoth(symbols, "sup2;", HtmlEntityService.Convert(178));
      HtmlEntityService.AddBoth(symbols, "sup3;", HtmlEntityService.Convert(179));
      HtmlEntityService.AddSingle(symbols, "supdot;", HtmlEntityService.Convert(10942));
      HtmlEntityService.AddSingle(symbols, "supdsub;", HtmlEntityService.Convert(10968));
      HtmlEntityService.AddSingle(symbols, "supE;", HtmlEntityService.Convert(10950));
      HtmlEntityService.AddSingle(symbols, "supe;", HtmlEntityService.Convert(8839));
      HtmlEntityService.AddSingle(symbols, "supedot;", HtmlEntityService.Convert(10948));
      HtmlEntityService.AddSingle(symbols, "suphsol;", HtmlEntityService.Convert(10185));
      HtmlEntityService.AddSingle(symbols, "suphsub;", HtmlEntityService.Convert(10967));
      HtmlEntityService.AddSingle(symbols, "suplarr;", HtmlEntityService.Convert(10619));
      HtmlEntityService.AddSingle(symbols, "supmult;", HtmlEntityService.Convert(10946));
      HtmlEntityService.AddSingle(symbols, "supnE;", HtmlEntityService.Convert(10956));
      HtmlEntityService.AddSingle(symbols, "supne;", HtmlEntityService.Convert(8843));
      HtmlEntityService.AddSingle(symbols, "supplus;", HtmlEntityService.Convert(10944));
      HtmlEntityService.AddSingle(symbols, "supset;", HtmlEntityService.Convert(8835));
      HtmlEntityService.AddSingle(symbols, "supseteq;", HtmlEntityService.Convert(8839));
      HtmlEntityService.AddSingle(symbols, "supseteqq;", HtmlEntityService.Convert(10950));
      HtmlEntityService.AddSingle(symbols, "supsetneq;", HtmlEntityService.Convert(8843));
      HtmlEntityService.AddSingle(symbols, "supsetneqq;", HtmlEntityService.Convert(10956));
      HtmlEntityService.AddSingle(symbols, "supsim;", HtmlEntityService.Convert(10952));
      HtmlEntityService.AddSingle(symbols, "supsub;", HtmlEntityService.Convert(10964));
      HtmlEntityService.AddSingle(symbols, "supsup;", HtmlEntityService.Convert(10966));
      HtmlEntityService.AddSingle(symbols, "swarhk;", HtmlEntityService.Convert(10534));
      HtmlEntityService.AddSingle(symbols, "swArr;", HtmlEntityService.Convert(8665));
      HtmlEntityService.AddSingle(symbols, "swarr;", HtmlEntityService.Convert(8601));
      HtmlEntityService.AddSingle(symbols, "swarrow;", HtmlEntityService.Convert(8601));
      HtmlEntityService.AddSingle(symbols, "swnwar;", HtmlEntityService.Convert(10538));
      HtmlEntityService.AddBoth(symbols, "szlig;", HtmlEntityService.Convert(223));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigS()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Sacute;", HtmlEntityService.Convert(346));
      HtmlEntityService.AddSingle(symbols, "Sc;", HtmlEntityService.Convert(10940));
      HtmlEntityService.AddSingle(symbols, "Scaron;", HtmlEntityService.Convert(352));
      HtmlEntityService.AddSingle(symbols, "Scedil;", HtmlEntityService.Convert(350));
      HtmlEntityService.AddSingle(symbols, "Scirc;", HtmlEntityService.Convert(348));
      HtmlEntityService.AddSingle(symbols, "Scy;", HtmlEntityService.Convert(1057));
      HtmlEntityService.AddSingle(symbols, "Sfr;", HtmlEntityService.Convert(120086));
      HtmlEntityService.AddSingle(symbols, "SHCHcy;", HtmlEntityService.Convert(1065));
      HtmlEntityService.AddSingle(symbols, "SHcy;", HtmlEntityService.Convert(1064));
      HtmlEntityService.AddSingle(symbols, "ShortDownArrow;", HtmlEntityService.Convert(8595));
      HtmlEntityService.AddSingle(symbols, "ShortLeftArrow;", HtmlEntityService.Convert(8592));
      HtmlEntityService.AddSingle(symbols, "ShortRightArrow;", HtmlEntityService.Convert(8594));
      HtmlEntityService.AddSingle(symbols, "ShortUpArrow;", HtmlEntityService.Convert(8593));
      HtmlEntityService.AddSingle(symbols, "Sigma;", HtmlEntityService.Convert(931));
      HtmlEntityService.AddSingle(symbols, "SmallCircle;", HtmlEntityService.Convert(8728));
      HtmlEntityService.AddSingle(symbols, "SOFTcy;", HtmlEntityService.Convert(1068));
      HtmlEntityService.AddSingle(symbols, "Sopf;", HtmlEntityService.Convert(120138));
      HtmlEntityService.AddSingle(symbols, "Sqrt;", HtmlEntityService.Convert(8730));
      HtmlEntityService.AddSingle(symbols, "Square;", HtmlEntityService.Convert(9633));
      HtmlEntityService.AddSingle(symbols, "SquareIntersection;", HtmlEntityService.Convert(8851));
      HtmlEntityService.AddSingle(symbols, "SquareSubset;", HtmlEntityService.Convert(8847));
      HtmlEntityService.AddSingle(symbols, "SquareSubsetEqual;", HtmlEntityService.Convert(8849));
      HtmlEntityService.AddSingle(symbols, "SquareSuperset;", HtmlEntityService.Convert(8848));
      HtmlEntityService.AddSingle(symbols, "SquareSupersetEqual;", HtmlEntityService.Convert(8850));
      HtmlEntityService.AddSingle(symbols, "SquareUnion;", HtmlEntityService.Convert(8852));
      HtmlEntityService.AddSingle(symbols, "Sscr;", HtmlEntityService.Convert(119982));
      HtmlEntityService.AddSingle(symbols, "Star;", HtmlEntityService.Convert(8902));
      HtmlEntityService.AddSingle(symbols, "Sub;", HtmlEntityService.Convert(8912));
      HtmlEntityService.AddSingle(symbols, "Subset;", HtmlEntityService.Convert(8912));
      HtmlEntityService.AddSingle(symbols, "SubsetEqual;", HtmlEntityService.Convert(8838));
      HtmlEntityService.AddSingle(symbols, "Succeeds;", HtmlEntityService.Convert(8827));
      HtmlEntityService.AddSingle(symbols, "SucceedsEqual;", HtmlEntityService.Convert(10928));
      HtmlEntityService.AddSingle(symbols, "SucceedsSlantEqual;", HtmlEntityService.Convert(8829));
      HtmlEntityService.AddSingle(symbols, "SucceedsTilde;", HtmlEntityService.Convert(8831));
      HtmlEntityService.AddSingle(symbols, "SuchThat;", HtmlEntityService.Convert(8715));
      HtmlEntityService.AddSingle(symbols, "Sum;", HtmlEntityService.Convert(8721));
      HtmlEntityService.AddSingle(symbols, "Sup;", HtmlEntityService.Convert(8913));
      HtmlEntityService.AddSingle(symbols, "Superset;", HtmlEntityService.Convert(8835));
      HtmlEntityService.AddSingle(symbols, "SupersetEqual;", HtmlEntityService.Convert(8839));
      HtmlEntityService.AddSingle(symbols, "Supset;", HtmlEntityService.Convert(8913));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleT()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "target;", HtmlEntityService.Convert(8982));
      HtmlEntityService.AddSingle(symbols, "tau;", HtmlEntityService.Convert(964));
      HtmlEntityService.AddSingle(symbols, "tbrk;", HtmlEntityService.Convert(9140));
      HtmlEntityService.AddSingle(symbols, "tcaron;", HtmlEntityService.Convert(357));
      HtmlEntityService.AddSingle(symbols, "tcedil;", HtmlEntityService.Convert(355));
      HtmlEntityService.AddSingle(symbols, "tcy;", HtmlEntityService.Convert(1090));
      HtmlEntityService.AddSingle(symbols, "tdot;", HtmlEntityService.Convert(8411));
      HtmlEntityService.AddSingle(symbols, "telrec;", HtmlEntityService.Convert(8981));
      HtmlEntityService.AddSingle(symbols, "tfr;", HtmlEntityService.Convert(120113));
      HtmlEntityService.AddSingle(symbols, "there4;", HtmlEntityService.Convert(8756));
      HtmlEntityService.AddSingle(symbols, "therefore;", HtmlEntityService.Convert(8756));
      HtmlEntityService.AddSingle(symbols, "theta;", HtmlEntityService.Convert(952));
      HtmlEntityService.AddSingle(symbols, "thetasym;", HtmlEntityService.Convert(977));
      HtmlEntityService.AddSingle(symbols, "thetav;", HtmlEntityService.Convert(977));
      HtmlEntityService.AddSingle(symbols, "thickapprox;", HtmlEntityService.Convert(8776));
      HtmlEntityService.AddSingle(symbols, "thicksim;", HtmlEntityService.Convert(8764));
      HtmlEntityService.AddSingle(symbols, "thinsp;", HtmlEntityService.Convert(8201));
      HtmlEntityService.AddSingle(symbols, "thkap;", HtmlEntityService.Convert(8776));
      HtmlEntityService.AddSingle(symbols, "thksim;", HtmlEntityService.Convert(8764));
      HtmlEntityService.AddBoth(symbols, "thorn;", HtmlEntityService.Convert(254));
      HtmlEntityService.AddSingle(symbols, "tilde;", HtmlEntityService.Convert(732));
      HtmlEntityService.AddBoth(symbols, "times;", HtmlEntityService.Convert(215));
      HtmlEntityService.AddSingle(symbols, "timesb;", HtmlEntityService.Convert(8864));
      HtmlEntityService.AddSingle(symbols, "timesbar;", HtmlEntityService.Convert(10801));
      HtmlEntityService.AddSingle(symbols, "timesd;", HtmlEntityService.Convert(10800));
      HtmlEntityService.AddSingle(symbols, "tint;", HtmlEntityService.Convert(8749));
      HtmlEntityService.AddSingle(symbols, "toea;", HtmlEntityService.Convert(10536));
      HtmlEntityService.AddSingle(symbols, "top;", HtmlEntityService.Convert(8868));
      HtmlEntityService.AddSingle(symbols, "topbot;", HtmlEntityService.Convert(9014));
      HtmlEntityService.AddSingle(symbols, "topcir;", HtmlEntityService.Convert(10993));
      HtmlEntityService.AddSingle(symbols, "topf;", HtmlEntityService.Convert(120165));
      HtmlEntityService.AddSingle(symbols, "topfork;", HtmlEntityService.Convert(10970));
      HtmlEntityService.AddSingle(symbols, "tosa;", HtmlEntityService.Convert(10537));
      HtmlEntityService.AddSingle(symbols, "tprime;", HtmlEntityService.Convert(8244));
      HtmlEntityService.AddSingle(symbols, "trade;", HtmlEntityService.Convert(8482));
      HtmlEntityService.AddSingle(symbols, "triangle;", HtmlEntityService.Convert(9653));
      HtmlEntityService.AddSingle(symbols, "triangledown;", HtmlEntityService.Convert(9663));
      HtmlEntityService.AddSingle(symbols, "triangleleft;", HtmlEntityService.Convert(9667));
      HtmlEntityService.AddSingle(symbols, "trianglelefteq;", HtmlEntityService.Convert(8884));
      HtmlEntityService.AddSingle(symbols, "triangleq;", HtmlEntityService.Convert(8796));
      HtmlEntityService.AddSingle(symbols, "triangleright;", HtmlEntityService.Convert(9657));
      HtmlEntityService.AddSingle(symbols, "trianglerighteq;", HtmlEntityService.Convert(8885));
      HtmlEntityService.AddSingle(symbols, "tridot;", HtmlEntityService.Convert(9708));
      HtmlEntityService.AddSingle(symbols, "trie;", HtmlEntityService.Convert(8796));
      HtmlEntityService.AddSingle(symbols, "triminus;", HtmlEntityService.Convert(10810));
      HtmlEntityService.AddSingle(symbols, "triplus;", HtmlEntityService.Convert(10809));
      HtmlEntityService.AddSingle(symbols, "trisb;", HtmlEntityService.Convert(10701));
      HtmlEntityService.AddSingle(symbols, "tritime;", HtmlEntityService.Convert(10811));
      HtmlEntityService.AddSingle(symbols, "trpezium;", HtmlEntityService.Convert(9186));
      HtmlEntityService.AddSingle(symbols, "tscr;", HtmlEntityService.Convert(120009));
      HtmlEntityService.AddSingle(symbols, "tscy;", HtmlEntityService.Convert(1094));
      HtmlEntityService.AddSingle(symbols, "tshcy;", HtmlEntityService.Convert(1115));
      HtmlEntityService.AddSingle(symbols, "tstrok;", HtmlEntityService.Convert(359));
      HtmlEntityService.AddSingle(symbols, "twixt;", HtmlEntityService.Convert(8812));
      HtmlEntityService.AddSingle(symbols, "twoheadleftarrow;", HtmlEntityService.Convert(8606));
      HtmlEntityService.AddSingle(symbols, "twoheadrightarrow;", HtmlEntityService.Convert(8608));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigT()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Tab;", HtmlEntityService.Convert(9));
      HtmlEntityService.AddSingle(symbols, "Tau;", HtmlEntityService.Convert(932));
      HtmlEntityService.AddSingle(symbols, "Tcaron;", HtmlEntityService.Convert(356));
      HtmlEntityService.AddSingle(symbols, "Tcedil;", HtmlEntityService.Convert(354));
      HtmlEntityService.AddSingle(symbols, "Tcy;", HtmlEntityService.Convert(1058));
      HtmlEntityService.AddSingle(symbols, "Tfr;", HtmlEntityService.Convert(120087));
      HtmlEntityService.AddSingle(symbols, "Therefore;", HtmlEntityService.Convert(8756));
      HtmlEntityService.AddSingle(symbols, "Theta;", HtmlEntityService.Convert(920));
      HtmlEntityService.AddSingle(symbols, "ThickSpace;", HtmlEntityService.Convert(8287, 8202));
      HtmlEntityService.AddSingle(symbols, "ThinSpace;", HtmlEntityService.Convert(8201));
      HtmlEntityService.AddBoth(symbols, "THORN;", HtmlEntityService.Convert(222));
      HtmlEntityService.AddSingle(symbols, "Tilde;", HtmlEntityService.Convert(8764));
      HtmlEntityService.AddSingle(symbols, "TildeEqual;", HtmlEntityService.Convert(8771));
      HtmlEntityService.AddSingle(symbols, "TildeFullEqual;", HtmlEntityService.Convert(8773));
      HtmlEntityService.AddSingle(symbols, "TildeTilde;", HtmlEntityService.Convert(8776));
      HtmlEntityService.AddSingle(symbols, "Topf;", HtmlEntityService.Convert(120139));
      HtmlEntityService.AddSingle(symbols, "TRADE;", HtmlEntityService.Convert(8482));
      HtmlEntityService.AddSingle(symbols, "TripleDot;", HtmlEntityService.Convert(8411));
      HtmlEntityService.AddSingle(symbols, "Tscr;", HtmlEntityService.Convert(119983));
      HtmlEntityService.AddSingle(symbols, "TScy;", HtmlEntityService.Convert(1062));
      HtmlEntityService.AddSingle(symbols, "TSHcy;", HtmlEntityService.Convert(1035));
      HtmlEntityService.AddSingle(symbols, "Tstrok;", HtmlEntityService.Convert(358));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleU()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddBoth(symbols, "uacute;", HtmlEntityService.Convert(250));
      HtmlEntityService.AddSingle(symbols, "uArr;", HtmlEntityService.Convert(8657));
      HtmlEntityService.AddSingle(symbols, "uarr;", HtmlEntityService.Convert(8593));
      HtmlEntityService.AddSingle(symbols, "ubrcy;", HtmlEntityService.Convert(1118));
      HtmlEntityService.AddSingle(symbols, "ubreve;", HtmlEntityService.Convert(365));
      HtmlEntityService.AddBoth(symbols, "ucirc;", HtmlEntityService.Convert(251));
      HtmlEntityService.AddSingle(symbols, "ucy;", HtmlEntityService.Convert(1091));
      HtmlEntityService.AddSingle(symbols, "udarr;", HtmlEntityService.Convert(8645));
      HtmlEntityService.AddSingle(symbols, "udblac;", HtmlEntityService.Convert(369));
      HtmlEntityService.AddSingle(symbols, "udhar;", HtmlEntityService.Convert(10606));
      HtmlEntityService.AddSingle(symbols, "ufisht;", HtmlEntityService.Convert(10622));
      HtmlEntityService.AddSingle(symbols, "ufr;", HtmlEntityService.Convert(120114));
      HtmlEntityService.AddBoth(symbols, "ugrave;", HtmlEntityService.Convert(249));
      HtmlEntityService.AddSingle(symbols, "uHar;", HtmlEntityService.Convert(10595));
      HtmlEntityService.AddSingle(symbols, "uharl;", HtmlEntityService.Convert(8639));
      HtmlEntityService.AddSingle(symbols, "uharr;", HtmlEntityService.Convert(8638));
      HtmlEntityService.AddSingle(symbols, "uhblk;", HtmlEntityService.Convert(9600));
      HtmlEntityService.AddSingle(symbols, "ulcorn;", HtmlEntityService.Convert(8988));
      HtmlEntityService.AddSingle(symbols, "ulcorner;", HtmlEntityService.Convert(8988));
      HtmlEntityService.AddSingle(symbols, "ulcrop;", HtmlEntityService.Convert(8975));
      HtmlEntityService.AddSingle(symbols, "ultri;", HtmlEntityService.Convert(9720));
      HtmlEntityService.AddSingle(symbols, "umacr;", HtmlEntityService.Convert(363));
      HtmlEntityService.AddBoth(symbols, "uml;", HtmlEntityService.Convert(168));
      HtmlEntityService.AddSingle(symbols, "uogon;", HtmlEntityService.Convert(371));
      HtmlEntityService.AddSingle(symbols, "uopf;", HtmlEntityService.Convert(120166));
      HtmlEntityService.AddSingle(symbols, "uparrow;", HtmlEntityService.Convert(8593));
      HtmlEntityService.AddSingle(symbols, "updownarrow;", HtmlEntityService.Convert(8597));
      HtmlEntityService.AddSingle(symbols, "upharpoonleft;", HtmlEntityService.Convert(8639));
      HtmlEntityService.AddSingle(symbols, "upharpoonright;", HtmlEntityService.Convert(8638));
      HtmlEntityService.AddSingle(symbols, "uplus;", HtmlEntityService.Convert(8846));
      HtmlEntityService.AddSingle(symbols, "upsi;", HtmlEntityService.Convert(965));
      HtmlEntityService.AddSingle(symbols, "upsih;", HtmlEntityService.Convert(978));
      HtmlEntityService.AddSingle(symbols, "upsilon;", HtmlEntityService.Convert(965));
      HtmlEntityService.AddSingle(symbols, "upuparrows;", HtmlEntityService.Convert(8648));
      HtmlEntityService.AddSingle(symbols, "urcorn;", HtmlEntityService.Convert(8989));
      HtmlEntityService.AddSingle(symbols, "urcorner;", HtmlEntityService.Convert(8989));
      HtmlEntityService.AddSingle(symbols, "urcrop;", HtmlEntityService.Convert(8974));
      HtmlEntityService.AddSingle(symbols, "uring;", HtmlEntityService.Convert(367));
      HtmlEntityService.AddSingle(symbols, "urtri;", HtmlEntityService.Convert(9721));
      HtmlEntityService.AddSingle(symbols, "uscr;", HtmlEntityService.Convert(120010));
      HtmlEntityService.AddSingle(symbols, "utdot;", HtmlEntityService.Convert(8944));
      HtmlEntityService.AddSingle(symbols, "utilde;", HtmlEntityService.Convert(361));
      HtmlEntityService.AddSingle(symbols, "utri;", HtmlEntityService.Convert(9653));
      HtmlEntityService.AddSingle(symbols, "utrif;", HtmlEntityService.Convert(9652));
      HtmlEntityService.AddSingle(symbols, "uuarr;", HtmlEntityService.Convert(8648));
      HtmlEntityService.AddBoth(symbols, "uuml;", HtmlEntityService.Convert(252));
      HtmlEntityService.AddSingle(symbols, "uwangle;", HtmlEntityService.Convert(10663));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigU()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddBoth(symbols, "Uacute;", HtmlEntityService.Convert(218));
      HtmlEntityService.AddSingle(symbols, "Uarr;", HtmlEntityService.Convert(8607));
      HtmlEntityService.AddSingle(symbols, "Uarrocir;", HtmlEntityService.Convert(10569));
      HtmlEntityService.AddSingle(symbols, "Ubrcy;", HtmlEntityService.Convert(1038));
      HtmlEntityService.AddSingle(symbols, "Ubreve;", HtmlEntityService.Convert(364));
      HtmlEntityService.AddBoth(symbols, "Ucirc;", HtmlEntityService.Convert(219));
      HtmlEntityService.AddSingle(symbols, "Ucy;", HtmlEntityService.Convert(1059));
      HtmlEntityService.AddSingle(symbols, "Udblac;", HtmlEntityService.Convert(368));
      HtmlEntityService.AddSingle(symbols, "Ufr;", HtmlEntityService.Convert(120088));
      HtmlEntityService.AddBoth(symbols, "Ugrave;", HtmlEntityService.Convert(217));
      HtmlEntityService.AddSingle(symbols, "Umacr;", HtmlEntityService.Convert(362));
      HtmlEntityService.AddSingle(symbols, "UnderBar;", HtmlEntityService.Convert(95));
      HtmlEntityService.AddSingle(symbols, "UnderBrace;", HtmlEntityService.Convert(9183));
      HtmlEntityService.AddSingle(symbols, "UnderBracket;", HtmlEntityService.Convert(9141));
      HtmlEntityService.AddSingle(symbols, "UnderParenthesis;", HtmlEntityService.Convert(9181));
      HtmlEntityService.AddSingle(symbols, "Union;", HtmlEntityService.Convert(8899));
      HtmlEntityService.AddSingle(symbols, "UnionPlus;", HtmlEntityService.Convert(8846));
      HtmlEntityService.AddSingle(symbols, "Uogon;", HtmlEntityService.Convert(370));
      HtmlEntityService.AddSingle(symbols, "Uopf;", HtmlEntityService.Convert(120140));
      HtmlEntityService.AddSingle(symbols, "UpArrow;", HtmlEntityService.Convert(8593));
      HtmlEntityService.AddSingle(symbols, "Uparrow;", HtmlEntityService.Convert(8657));
      HtmlEntityService.AddSingle(symbols, "UpArrowBar;", HtmlEntityService.Convert(10514));
      HtmlEntityService.AddSingle(symbols, "UpArrowDownArrow;", HtmlEntityService.Convert(8645));
      HtmlEntityService.AddSingle(symbols, "UpDownArrow;", HtmlEntityService.Convert(8597));
      HtmlEntityService.AddSingle(symbols, "Updownarrow;", HtmlEntityService.Convert(8661));
      HtmlEntityService.AddSingle(symbols, "UpEquilibrium;", HtmlEntityService.Convert(10606));
      HtmlEntityService.AddSingle(symbols, "UpperLeftArrow;", HtmlEntityService.Convert(8598));
      HtmlEntityService.AddSingle(symbols, "UpperRightArrow;", HtmlEntityService.Convert(8599));
      HtmlEntityService.AddSingle(symbols, "Upsi;", HtmlEntityService.Convert(978));
      HtmlEntityService.AddSingle(symbols, "Upsilon;", HtmlEntityService.Convert(933));
      HtmlEntityService.AddSingle(symbols, "UpTee;", HtmlEntityService.Convert(8869));
      HtmlEntityService.AddSingle(symbols, "UpTeeArrow;", HtmlEntityService.Convert(8613));
      HtmlEntityService.AddSingle(symbols, "Uring;", HtmlEntityService.Convert(366));
      HtmlEntityService.AddSingle(symbols, "Uscr;", HtmlEntityService.Convert(119984));
      HtmlEntityService.AddSingle(symbols, "Utilde;", HtmlEntityService.Convert(360));
      HtmlEntityService.AddBoth(symbols, "Uuml;", HtmlEntityService.Convert(220));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleV()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "vangrt;", HtmlEntityService.Convert(10652));
      HtmlEntityService.AddSingle(symbols, "varepsilon;", HtmlEntityService.Convert(1013));
      HtmlEntityService.AddSingle(symbols, "varkappa;", HtmlEntityService.Convert(1008));
      HtmlEntityService.AddSingle(symbols, "varnothing;", HtmlEntityService.Convert(8709));
      HtmlEntityService.AddSingle(symbols, "varphi;", HtmlEntityService.Convert(981));
      HtmlEntityService.AddSingle(symbols, "varpi;", HtmlEntityService.Convert(982));
      HtmlEntityService.AddSingle(symbols, "varpropto;", HtmlEntityService.Convert(8733));
      HtmlEntityService.AddSingle(symbols, "vArr;", HtmlEntityService.Convert(8661));
      HtmlEntityService.AddSingle(symbols, "varr;", HtmlEntityService.Convert(8597));
      HtmlEntityService.AddSingle(symbols, "varrho;", HtmlEntityService.Convert(1009));
      HtmlEntityService.AddSingle(symbols, "varsigma;", HtmlEntityService.Convert(962));
      HtmlEntityService.AddSingle(symbols, "varsubsetneq;", HtmlEntityService.Convert(8842, 65024));
      HtmlEntityService.AddSingle(symbols, "varsubsetneqq;", HtmlEntityService.Convert(10955, 65024));
      HtmlEntityService.AddSingle(symbols, "varsupsetneq;", HtmlEntityService.Convert(8843, 65024));
      HtmlEntityService.AddSingle(symbols, "varsupsetneqq;", HtmlEntityService.Convert(10956, 65024));
      HtmlEntityService.AddSingle(symbols, "vartheta;", HtmlEntityService.Convert(977));
      HtmlEntityService.AddSingle(symbols, "vartriangleleft;", HtmlEntityService.Convert(8882));
      HtmlEntityService.AddSingle(symbols, "vartriangleright;", HtmlEntityService.Convert(8883));
      HtmlEntityService.AddSingle(symbols, "vBar;", HtmlEntityService.Convert(10984));
      HtmlEntityService.AddSingle(symbols, "vBarv;", HtmlEntityService.Convert(10985));
      HtmlEntityService.AddSingle(symbols, "vcy;", HtmlEntityService.Convert(1074));
      HtmlEntityService.AddSingle(symbols, "vDash;", HtmlEntityService.Convert(8872));
      HtmlEntityService.AddSingle(symbols, "vdash;", HtmlEntityService.Convert(8866));
      HtmlEntityService.AddSingle(symbols, "vee;", HtmlEntityService.Convert(8744));
      HtmlEntityService.AddSingle(symbols, "veebar;", HtmlEntityService.Convert(8891));
      HtmlEntityService.AddSingle(symbols, "veeeq;", HtmlEntityService.Convert(8794));
      HtmlEntityService.AddSingle(symbols, "vellip;", HtmlEntityService.Convert(8942));
      HtmlEntityService.AddSingle(symbols, "verbar;", HtmlEntityService.Convert(124));
      HtmlEntityService.AddSingle(symbols, "vert;", HtmlEntityService.Convert(124));
      HtmlEntityService.AddSingle(symbols, "vfr;", HtmlEntityService.Convert(120115));
      HtmlEntityService.AddSingle(symbols, "vltri;", HtmlEntityService.Convert(8882));
      HtmlEntityService.AddSingle(symbols, "vnsub;", HtmlEntityService.Convert(8834, 8402));
      HtmlEntityService.AddSingle(symbols, "vnsup;", HtmlEntityService.Convert(8835, 8402));
      HtmlEntityService.AddSingle(symbols, "vopf;", HtmlEntityService.Convert(120167));
      HtmlEntityService.AddSingle(symbols, "vprop;", HtmlEntityService.Convert(8733));
      HtmlEntityService.AddSingle(symbols, "vrtri;", HtmlEntityService.Convert(8883));
      HtmlEntityService.AddSingle(symbols, "vscr;", HtmlEntityService.Convert(120011));
      HtmlEntityService.AddSingle(symbols, "vsubnE;", HtmlEntityService.Convert(10955, 65024));
      HtmlEntityService.AddSingle(symbols, "vsubne;", HtmlEntityService.Convert(8842, 65024));
      HtmlEntityService.AddSingle(symbols, "vsupnE;", HtmlEntityService.Convert(10956, 65024));
      HtmlEntityService.AddSingle(symbols, "vsupne;", HtmlEntityService.Convert(8843, 65024));
      HtmlEntityService.AddSingle(symbols, "vzigzag;", HtmlEntityService.Convert(10650));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigV()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Vbar;", HtmlEntityService.Convert(10987));
      HtmlEntityService.AddSingle(symbols, "Vcy;", HtmlEntityService.Convert(1042));
      HtmlEntityService.AddSingle(symbols, "VDash;", HtmlEntityService.Convert(8875));
      HtmlEntityService.AddSingle(symbols, "Vdash;", HtmlEntityService.Convert(8873));
      HtmlEntityService.AddSingle(symbols, "Vdashl;", HtmlEntityService.Convert(10982));
      HtmlEntityService.AddSingle(symbols, "Vee;", HtmlEntityService.Convert(8897));
      HtmlEntityService.AddSingle(symbols, "Verbar;", HtmlEntityService.Convert(8214));
      HtmlEntityService.AddSingle(symbols, "Vert;", HtmlEntityService.Convert(8214));
      HtmlEntityService.AddSingle(symbols, "VerticalBar;", HtmlEntityService.Convert(8739));
      HtmlEntityService.AddSingle(symbols, "VerticalLine;", HtmlEntityService.Convert(124));
      HtmlEntityService.AddSingle(symbols, "VerticalSeparator;", HtmlEntityService.Convert(10072));
      HtmlEntityService.AddSingle(symbols, "VerticalTilde;", HtmlEntityService.Convert(8768));
      HtmlEntityService.AddSingle(symbols, "VeryThinSpace;", HtmlEntityService.Convert(8202));
      HtmlEntityService.AddSingle(symbols, "Vfr;", HtmlEntityService.Convert(120089));
      HtmlEntityService.AddSingle(symbols, "Vopf;", HtmlEntityService.Convert(120141));
      HtmlEntityService.AddSingle(symbols, "Vscr;", HtmlEntityService.Convert(119985));
      HtmlEntityService.AddSingle(symbols, "Vvdash;", HtmlEntityService.Convert(8874));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleW()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "wcirc;", HtmlEntityService.Convert(373));
      HtmlEntityService.AddSingle(symbols, "wedbar;", HtmlEntityService.Convert(10847));
      HtmlEntityService.AddSingle(symbols, "wedge;", HtmlEntityService.Convert(8743));
      HtmlEntityService.AddSingle(symbols, "wedgeq;", HtmlEntityService.Convert(8793));
      HtmlEntityService.AddSingle(symbols, "weierp;", HtmlEntityService.Convert(8472));
      HtmlEntityService.AddSingle(symbols, "wfr;", HtmlEntityService.Convert(120116));
      HtmlEntityService.AddSingle(symbols, "wopf;", HtmlEntityService.Convert(120168));
      HtmlEntityService.AddSingle(symbols, "wp;", HtmlEntityService.Convert(8472));
      HtmlEntityService.AddSingle(symbols, "wr;", HtmlEntityService.Convert(8768));
      HtmlEntityService.AddSingle(symbols, "wreath;", HtmlEntityService.Convert(8768));
      HtmlEntityService.AddSingle(symbols, "wscr;", HtmlEntityService.Convert(120012));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigW()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Wcirc;", HtmlEntityService.Convert(372));
      HtmlEntityService.AddSingle(symbols, "Wedge;", HtmlEntityService.Convert(8896));
      HtmlEntityService.AddSingle(symbols, "Wfr;", HtmlEntityService.Convert(120090));
      HtmlEntityService.AddSingle(symbols, "Wopf;", HtmlEntityService.Convert(120142));
      HtmlEntityService.AddSingle(symbols, "Wscr;", HtmlEntityService.Convert(119986));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleX()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "xcap;", HtmlEntityService.Convert(8898));
      HtmlEntityService.AddSingle(symbols, "xcirc;", HtmlEntityService.Convert(9711));
      HtmlEntityService.AddSingle(symbols, "xcup;", HtmlEntityService.Convert(8899));
      HtmlEntityService.AddSingle(symbols, "xdtri;", HtmlEntityService.Convert(9661));
      HtmlEntityService.AddSingle(symbols, "xfr;", HtmlEntityService.Convert(120117));
      HtmlEntityService.AddSingle(symbols, "xhArr;", HtmlEntityService.Convert(10234));
      HtmlEntityService.AddSingle(symbols, "xharr;", HtmlEntityService.Convert(10231));
      HtmlEntityService.AddSingle(symbols, "xi;", HtmlEntityService.Convert(958));
      HtmlEntityService.AddSingle(symbols, "xlArr;", HtmlEntityService.Convert(10232));
      HtmlEntityService.AddSingle(symbols, "xlarr;", HtmlEntityService.Convert(10229));
      HtmlEntityService.AddSingle(symbols, "xmap;", HtmlEntityService.Convert(10236));
      HtmlEntityService.AddSingle(symbols, "xnis;", HtmlEntityService.Convert(8955));
      HtmlEntityService.AddSingle(symbols, "xodot;", HtmlEntityService.Convert(10752));
      HtmlEntityService.AddSingle(symbols, "xopf;", HtmlEntityService.Convert(120169));
      HtmlEntityService.AddSingle(symbols, "xoplus;", HtmlEntityService.Convert(10753));
      HtmlEntityService.AddSingle(symbols, "xotime;", HtmlEntityService.Convert(10754));
      HtmlEntityService.AddSingle(symbols, "xrArr;", HtmlEntityService.Convert(10233));
      HtmlEntityService.AddSingle(symbols, "xrarr;", HtmlEntityService.Convert(10230));
      HtmlEntityService.AddSingle(symbols, "xscr;", HtmlEntityService.Convert(120013));
      HtmlEntityService.AddSingle(symbols, "xsqcup;", HtmlEntityService.Convert(10758));
      HtmlEntityService.AddSingle(symbols, "xuplus;", HtmlEntityService.Convert(10756));
      HtmlEntityService.AddSingle(symbols, "xutri;", HtmlEntityService.Convert(9651));
      HtmlEntityService.AddSingle(symbols, "xvee;", HtmlEntityService.Convert(8897));
      HtmlEntityService.AddSingle(symbols, "xwedge;", HtmlEntityService.Convert(8896));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigX()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Xfr;", HtmlEntityService.Convert(120091));
      HtmlEntityService.AddSingle(symbols, "Xi;", HtmlEntityService.Convert(926));
      HtmlEntityService.AddSingle(symbols, "Xopf;", HtmlEntityService.Convert(120143));
      HtmlEntityService.AddSingle(symbols, "Xscr;", HtmlEntityService.Convert(119987));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleY()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddBoth(symbols, "yacute;", HtmlEntityService.Convert(253));
      HtmlEntityService.AddSingle(symbols, "yacy;", HtmlEntityService.Convert(1103));
      HtmlEntityService.AddSingle(symbols, "ycirc;", HtmlEntityService.Convert(375));
      HtmlEntityService.AddSingle(symbols, "ycy;", HtmlEntityService.Convert(1099));
      HtmlEntityService.AddBoth(symbols, "yen;", HtmlEntityService.Convert(165));
      HtmlEntityService.AddSingle(symbols, "yfr;", HtmlEntityService.Convert(120118));
      HtmlEntityService.AddSingle(symbols, "yicy;", HtmlEntityService.Convert(1111));
      HtmlEntityService.AddSingle(symbols, "yopf;", HtmlEntityService.Convert(120170));
      HtmlEntityService.AddSingle(symbols, "yscr;", HtmlEntityService.Convert(120014));
      HtmlEntityService.AddSingle(symbols, "yucy;", HtmlEntityService.Convert(1102));
      HtmlEntityService.AddBoth(symbols, "yuml;", HtmlEntityService.Convert((int) byte.MaxValue));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigY()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddBoth(symbols, "Yacute;", HtmlEntityService.Convert(221));
      HtmlEntityService.AddSingle(symbols, "YAcy;", HtmlEntityService.Convert(1071));
      HtmlEntityService.AddSingle(symbols, "Ycirc;", HtmlEntityService.Convert(374));
      HtmlEntityService.AddSingle(symbols, "Ycy;", HtmlEntityService.Convert(1067));
      HtmlEntityService.AddSingle(symbols, "Yfr;", HtmlEntityService.Convert(120092));
      HtmlEntityService.AddSingle(symbols, "YIcy;", HtmlEntityService.Convert(1031));
      HtmlEntityService.AddSingle(symbols, "Yopf;", HtmlEntityService.Convert(120144));
      HtmlEntityService.AddSingle(symbols, "Yscr;", HtmlEntityService.Convert(119988));
      HtmlEntityService.AddSingle(symbols, "YUcy;", HtmlEntityService.Convert(1070));
      HtmlEntityService.AddSingle(symbols, "Yuml;", HtmlEntityService.Convert(376));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolLittleZ()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "zacute;", HtmlEntityService.Convert(378));
      HtmlEntityService.AddSingle(symbols, "zcaron;", HtmlEntityService.Convert(382));
      HtmlEntityService.AddSingle(symbols, "zcy;", HtmlEntityService.Convert(1079));
      HtmlEntityService.AddSingle(symbols, "zdot;", HtmlEntityService.Convert(380));
      HtmlEntityService.AddSingle(symbols, "zeetrf;", HtmlEntityService.Convert(8488));
      HtmlEntityService.AddSingle(symbols, "zeta;", HtmlEntityService.Convert(950));
      HtmlEntityService.AddSingle(symbols, "zfr;", HtmlEntityService.Convert(120119));
      HtmlEntityService.AddSingle(symbols, "zhcy;", HtmlEntityService.Convert(1078));
      HtmlEntityService.AddSingle(symbols, "zigrarr;", HtmlEntityService.Convert(8669));
      HtmlEntityService.AddSingle(symbols, "zopf;", HtmlEntityService.Convert(120171));
      HtmlEntityService.AddSingle(symbols, "zscr;", HtmlEntityService.Convert(120015));
      HtmlEntityService.AddSingle(symbols, "zwj;", HtmlEntityService.Convert(8205));
      HtmlEntityService.AddSingle(symbols, "zwnj;", HtmlEntityService.Convert(8204));
      return symbols;
    }

    private Dictionary<string, string> GetSymbolBigZ()
    {
      Dictionary<string, string> symbols = new Dictionary<string, string>();
      HtmlEntityService.AddSingle(symbols, "Zacute;", HtmlEntityService.Convert(377));
      HtmlEntityService.AddSingle(symbols, "Zcaron;", HtmlEntityService.Convert(381));
      HtmlEntityService.AddSingle(symbols, "Zcy;", HtmlEntityService.Convert(1047));
      HtmlEntityService.AddSingle(symbols, "Zdot;", HtmlEntityService.Convert(379));
      HtmlEntityService.AddSingle(symbols, "ZeroWidthSpace;", HtmlEntityService.Convert(8203));
      HtmlEntityService.AddSingle(symbols, "Zeta;", HtmlEntityService.Convert(918));
      HtmlEntityService.AddSingle(symbols, "Zfr;", HtmlEntityService.Convert(8488));
      HtmlEntityService.AddSingle(symbols, "ZHcy;", HtmlEntityService.Convert(1046));
      HtmlEntityService.AddSingle(symbols, "Zopf;", HtmlEntityService.Convert(8484));
      HtmlEntityService.AddSingle(symbols, "Zscr;", HtmlEntityService.Convert(119989));
      return symbols;
    }

    public string GetSymbol(string name)
    {
      string symbol = (string) null;
      Dictionary<string, string> dictionary = (Dictionary<string, string>) null;
      if (!string.IsNullOrEmpty(name) && this._entities.TryGetValue(name[0], out dictionary))
        dictionary.TryGetValue(name, out symbol);
      return symbol;
    }

    private static string Convert(int code) => code.ConvertFromUtf32();

    private static string Convert(int leading, int trailing) => leading.ConvertFromUtf32() + trailing.ConvertFromUtf32();

    public static bool IsInvalidNumber(int code) => code >= 55296 && code <= 57343 || code < 0 || code > 1114111;

    public static bool IsInCharacterTable(int code) => code == 0 || code == 13 || code == 128 || code == 129 || code == 130 || code == 131 || code == 132 || code == 133 || code == 134 || code == 135 || code == 136 || code == 137 || code == 138 || code == 139 || code == 140 || code == 141 || code == 142 || code == 143 || code == 144 || code == 145 || code == 146 || code == 147 || code == 148 || code == 149 || code == 150 || code == 151 || code == 152 || code == 153 || code == 154 || code == 155 || code == 156 || code == 157 || code == 158 || code == 159;

    public static string GetSymbolFromTable(int code)
    {
      switch (code)
      {
        case 0:
          return HtmlEntityService.Convert(65533);
        case 13:
          return HtmlEntityService.Convert(13);
        case 128:
          return HtmlEntityService.Convert(8364);
        case 129:
          return HtmlEntityService.Convert(129);
        case 130:
          return HtmlEntityService.Convert(8218);
        case 131:
          return HtmlEntityService.Convert(402);
        case 132:
          return HtmlEntityService.Convert(8222);
        case 133:
          return HtmlEntityService.Convert(8230);
        case 134:
          return HtmlEntityService.Convert(8224);
        case 135:
          return HtmlEntityService.Convert(8225);
        case 136:
          return HtmlEntityService.Convert(710);
        case 137:
          return HtmlEntityService.Convert(8240);
        case 138:
          return HtmlEntityService.Convert(352);
        case 139:
          return HtmlEntityService.Convert(8249);
        case 140:
          return HtmlEntityService.Convert(338);
        case 141:
          return HtmlEntityService.Convert(141);
        case 142:
          return HtmlEntityService.Convert(381);
        case 143:
          return HtmlEntityService.Convert(143);
        case 144:
          return HtmlEntityService.Convert(144);
        case 145:
          return HtmlEntityService.Convert(8216);
        case 146:
          return HtmlEntityService.Convert(8217);
        case 147:
          return HtmlEntityService.Convert(8220);
        case 148:
          return HtmlEntityService.Convert(8221);
        case 149:
          return HtmlEntityService.Convert(8226);
        case 150:
          return HtmlEntityService.Convert(8211);
        case 151:
          return HtmlEntityService.Convert(8212);
        case 152:
          return HtmlEntityService.Convert(732);
        case 153:
          return HtmlEntityService.Convert(8482);
        case 154:
          return HtmlEntityService.Convert(353);
        case 155:
          return HtmlEntityService.Convert(8250);
        case 156:
          return HtmlEntityService.Convert(339);
        case 157:
          return HtmlEntityService.Convert(157);
        case 158:
          return HtmlEntityService.Convert(382);
        case 159:
          return HtmlEntityService.Convert(376);
        default:
          return (string) null;
      }
    }

    public static bool IsInInvalidRange(int code) => code >= 1 && code <= 8 || code >= 14 && code <= 31 || code >= (int) sbyte.MaxValue && code <= 159 || code >= 64976 && code <= 65007 || code == 11 || code == 65534 || code == (int) ushort.MaxValue || code == 131070 || code == 196606 || code == 131071 || code == 196607 || code == 262142 || code == 262143 || code == 327678 || code == 327679 || code == 393214 || code == 393215 || code == 458750 || code == 458751 || code == 524286 || code == 524287 || code == 589822 || code == 589823 || code == 655358 || code == 655359 || code == 720894 || code == 720895 || code == 786430 || code == 786431 || code == 851966 || code == 851967 || code == 917502 || code == 917503 || code == 983038 || code == 983039 || code == 1048574 || code == 1048575 || code == 1114110 || code == 1114111;

    private static void AddSingle(Dictionary<string, string> symbols, string key, string value) => symbols.Add(key, value);

    private static void AddBoth(Dictionary<string, string> symbols, string key, string value)
    {
      symbols.Add(key, value);
      symbols.Add(key.Remove(key.Length - 1), value);
    }
  }
}
