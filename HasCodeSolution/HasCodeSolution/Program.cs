using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using HasCodeSolution.Models;

namespace HasCodeSolution
{
     class Program
    {
        static readonly string TextFile = @"C:\Users\ASUS\HasCode\c_coarse.in.txt";
        
        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines(TextFile);
            string usersCount = text[0].Trim();
            List<User> users = new List<User>();
            int userId = 1; 
            for (int i = 1; i < text.Length; i+=2)
            {
                User user = new User();
                user.Id = userId;
                user.LikedIngr = text[i].Split(' ');
                if (i != text.Length -1)
                {
                    user.DisLikeIngr = text[i + 1].Split(' ');
                }
                user.UserLikedIngrPoint = user.LikedIngr[0];
                user.UserDisLikedIngrPoint = user.DisLikeIngr[0];

                users.Add(user);
                userId++;
            }
            foreach (User user in users)
            {
                Console.WriteLine($"User {user.Id} Liked : {user.GetLikedIngr()} But Dislike : {user.GetDisLikedIngr()} User liked Ing Point : {user.UserLikedIngrPoint} User DisLike Ing Point : {user.UserDisLikedIngrPoint} ");
            }
        }
    }
}
