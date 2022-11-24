using System.Collections.Generic;
using System;

public class RomanNumerals
{
    public static string ToRoman(int n)
    {
      Console.WriteLine(n + " num");
      string res = "";
      Dictionary<int, string> rom = new Dictionary<int, string>();
      rom.Add(1,"I");
      rom.Add(4,"IV");
      rom.Add(5,"V");
      rom.Add(9,"IX");
      rom.Add(10,"X");
      rom.Add(40,"XL");
      rom.Add(50,"L");
      rom.Add(90,"XC");
      rom.Add(100,"C");
      rom.Add(400,"CD");
      rom.Add(500,"D");
      rom.Add(900,"CM");
      rom.Add(1000,"M");
      
      int k = 1000;
      while(n != 0)
      {
        int m = n/k;
        if(m != 0)
        {
          if(m%9 == 0 || (m%4 == 0 && m%8 != 0))
          {
            res += rom[m*k];
          }
          else if(m%5 == 0 || m%6 == 0 || m%7 == 0 || m%8 == 0)
          {
            if(m%5 == 0)
              res = res + rom[5*k];
            else
            {
              res = res + rom[5*k];
              m = m - 5;
              for(int i = 0; i< m; i++)
                res += rom[k];
              m = m + 5;
            }
          }
          else
          {
            for(int i = 0; i< m; i++)
              res += rom[k];
          }
        }
        Console.WriteLine(k + " k; res = " + res);
        
        n = n - (m*k);
        k = k/10;
      }
      
      
      return res;
    }

    public static int FromRoman(string romanNumeral)
    {
      int res = 0;
      Dictionary<string, int> rom = new Dictionary<string, int>();
      rom.Add("I",1);
      rom.Add("IV",4);
      rom.Add("V",5);
      rom.Add("IX",9);
      rom.Add("X",10);
      rom.Add("XL",40);
      rom.Add("L",50);
      rom.Add("XC",90);
      rom.Add("C",100);
      rom.Add("CD",400);
      rom.Add("D",500);
      rom.Add("CM",900);
      rom.Add("M",1000);
      
      while(String.IsNullOrEmpty(romanNumeral) == false)
      {

        char cara = romanNumeral[0];
        int decal = 1;
        switch(cara)
        {
            case 'I':
              if(romanNumeral.Length > 1)
              {
                if(romanNumeral[1] == 'V')
                {
                  res += rom["IV"];
                  decal += 1;
                }
                else if(romanNumeral[1] == 'X')
                {
                  res += rom["IX"];
                  decal += 1;
                }
                else
                  res += rom["I"];
              }
              else
                 res += rom["I"];
              break;
            case 'X':
              if(romanNumeral.Length > 1)
              {
                if(romanNumeral[1] == 'L')
                {
                  res += rom["XL"];
                  decal += 1;
                }
                else if(romanNumeral[1] == 'C')
                {
                  res += rom["XC"];
                  decal += 1;
                }
                else
                  res += rom["X"];
              }
              else
                res += rom["X"];
              break;
            case 'C':
              if(romanNumeral.Length > 1)
              {
                if(romanNumeral[1] == 'D')
                {
                  res += rom["CD"];
                  decal += 1;
                }
                else if(romanNumeral[1] == 'M')
                {
                  res += rom["CM"];
                  decal += 1;
                }
                else
                  res += rom["C"];
              }
              else
                res += rom["C"];
              break;
            default:
              res += rom[cara.ToString()];
              break;   
        }
        
        if(romanNumeral.Length == 1 || (decal == 2 && romanNumeral.Length == 2))
          romanNumeral = null;
        else
          romanNumeral = romanNumeral.Substring(decal);
        
      }
      
      return res;
    }
  }