using System;
using System.Collections.Generic;
using System.IO;
using HasCodeSolution.Models;
using System.Linq;
using System.Data.Common;

namespace HasCodeSolution
{
     class Program
    { 
        static readonly string TextFile = @"C:\Users\ASUS\HasCode\d_difficult.in.txt";
        
        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines(TextFile);
            string usersCount = text[0].Trim();
            List<User> users = new List<User>();
            int userId = 1; 
            for (int i = 1; i < text.Length; i+=2)
            {
                User user = new User();
                user.No = userId;
                user.LikedIngr = text[i].Split(' ');
                if (i != text.Length -1)
                {
                    user.DisLikeIngr = text[i + 1].Split(' ');
                }
                user.UserLikedIngrPoint = double.Parse(user.LikedIngr[0]);
                user.UserDisLikedIngrPoint = double.Parse(user.DisLikeIngr[0]);

                users.Add(user);
                userId++;
            }
            int a;
            List<AllIngr> allIngrs = new List<AllIngr>();
            foreach (User user in users)
            {
                foreach (string all in user.DisLikeIngr)
                {
                    AllIngr allForGenericList = new AllIngr();
                    allForGenericList.Name = all;
                    if (!int.TryParse(all, out a))
                    {
                        allIngrs.Add(allForGenericList);
                    }
                }
                foreach (string all in user.LikedIngr)
                {
                    AllIngr allForGenericList = new AllIngr();

                    allForGenericList.Name = all;
                    if (!int.TryParse(all, out a))
                    {
                        allIngrs.Add(allForGenericList);
                    }
                }
            }
            allIngrs = allIngrs.Distinct().ToList();
            int b;
            List<DislikedIngr> disLikedIngr = new List<DislikedIngr>();
            foreach (User user in users)
            {
                foreach (string dislike in user.DisLikeIngr)
                {
                    DislikedIngr dislikeingrForGenericList = new DislikedIngr();
                    dislikeingrForGenericList.Name = dislike;
                    if (!int.TryParse(dislike, out b))
                    {
                        disLikedIngr.Add(dislikeingrForGenericList);
                    }
                }
            }
            disLikedIngr = disLikedIngr.Distinct().ToList();
            IEnumerable<string> allIngrs1 = allIngrs.Select(ingr => ingr.Name).Except(disLikedIngr.Select(ing => ing.Name));
            string finnalyIngr = "";
            foreach (string item in allIngrs1)
            {
                finnalyIngr += $"{item} ";
            }
            Console.WriteLine(finnalyIngr);
        }
    }
}
