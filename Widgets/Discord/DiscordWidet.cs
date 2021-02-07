using System;
using DSharpPlus;
using System.Threading.Tasks;

namespace DiscordWidget
{
    class Program
    {
        public static async Task<string> GetInputAsync()
        {
            return await Task.Run(() => Console.ReadLine());
        }


        public static DSharpPlus.Entities.DiscordChannel channel;

        static DiscordClient bot;
        static void Main(string[] args)
        {
            
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {


            bot = new DiscordClient(new DiscordConfiguration
            {
                Token = "THIS IS NOT MY TOKEN YOU DUMBASS";
                TokenType = TokenType.User
            });

            channel = bot.GetChannelAsync(704160396730171536).Result;

            bot.MessageCreated += async e =>
            {
                if (e.Message.Channel.Id == 704160396730171536)
                {
                    Console.WriteLine($"{e.Message.Author.Username} || {e.Message.Content}");
                }
            };


            while (true){
                string msg = GetInputAsync().Result;
                if (msg != "")
                {
                    await bot.SendMessageAsync(channel, msg, false, null);
                }
            }
            
            await bot.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
