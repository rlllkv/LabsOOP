using OOP_laba_1_2;

IDateTimeFormatter dateType = new AmericanDateTimeFormatter();
DecorPost post = new DecorPost(dateType);
DecorPre pre = new DecorPre(post);
DecorPost post2 = new DecorPost(pre);

Console.WriteLine(post2.FormatDateTime());
Console.ReadLine();

