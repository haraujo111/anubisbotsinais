using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;

class Program
{
    static TelegramBotClient Bot = null;
    static void Main(string[] args)
    {

        Bot = new TelegramBotClient("***********************");
        var me = Bot.GetMeAsync().Result;
        Console.Title = me.Username;

        Bot.OnMessage += BotOnMessageReceived;
        Bot.OnMessageEdited += BotOnMessageReceived;
        Bot.OnCallbackQuery += BotOnCallbackQueryReceived;
        Bot.OnInlineQuery += BotOnInlineQueryReceived;
        Bot.OnInlineResultChosen += BotOnChosenInlineResultReceived;
        Bot.OnReceiveError += BotOnReceiveError;

        Bot.StartReceiving(Array.Empty<UpdateType>());
        Console.WriteLine($"Start listening for @{me.Username}");

        Bot.SendTextMessageAsync("@anubis_sinais", "Olá, sou o AnubisTradeBot estou procurando oportunidades, assim que achar lhe aviso...");
        while (true)
        {
            //
            try
            {

                System.Data.DataTable dt = ClassDB.get("select * from yet8263mduem where few42fd = 0 and 432d23432 = 'BINANCE' order by rwe421 desc");
                if (dt.Rows.Count > 0)
                {                                        
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        String msg = " == SINAL DE COMPRA == " + Environment.NewLine + Environment.NewLine;
                        msg += "Data: " + DateTime.Parse(dt.Rows[i]["dta_data_buy"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") + Environment.NewLine;
                        msg += "Exchange: Binance" + Environment.NewLine;
                        msg += "Moeda: " + dt.Rows[i]["nom_coin"].ToString()+ Environment.NewLine + Environment.NewLine;
                        msg += "Comprar: " + Math.Round( decimal.Parse( dt.Rows[i]["ee21e3"].ToString().Replace(".",",")),8) + Environment.NewLine;
                        msg += "Target: " + Math.Round(decimal.Parse(dt.Rows[i]["321rew"].ToString().Replace(".", ",")), 8) + Environment.NewLine;
                        msg += "Stop: " + Math.Round(decimal.Parse(dt.Rows[i]["dqwdwq"].ToString().Replace(".", ",")), 8) + Environment.NewLine + Environment.NewLine;
                        msg += "Tempo gráfico: " + dt.Rows[i]["dqwdwq"].ToString() + Environment.NewLine + Environment.NewLine;
                        msg += "Acesse: https://anubis.website" + Environment.NewLine + Environment.NewLine;
                        msg += " == FINAL - SINAL DE COMPRA == " + Environment.NewLine;


                        Console.WriteLine(msg);
                        Bot.SendTextMessageAsync("@anubis_sinais", msg);
                        ClassDB.execS("update anubis_orders set num_telegram = 1 where cod_order = " + dt.Rows[i]["cod_order"].ToString());
                    }
                }

            }
            catch { }

            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine("Sleep 60s");
            System.Threading.Thread.Sleep(60000);

        }


        Console.ReadLine();
        Bot.StopReceiving();


    }


    private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
    {
        var message = messageEventArgs.Message;

        if (message == null || message.Type != MessageType.Text) return;

        switch (message.Text.Split(' ').First())
        {

        
        }
    }


    
    private static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
    {
        var callbackQuery = callbackQueryEventArgs.CallbackQuery;

        await Bot.AnswerCallbackQueryAsync(
            callbackQuery.Id,
            $"Received {callbackQuery.Data}");

        await Bot.SendTextMessageAsync(
            callbackQuery.Message.Chat.Id,
            $"Received {callbackQuery.Data}");
    }

    private static async void BotOnInlineQueryReceived(object sender, InlineQueryEventArgs inlineQueryEventArgs)
    {
        Console.WriteLine($"Received inline query from: {inlineQueryEventArgs.InlineQuery.From.Id}");

        

        await Bot.AnswerInlineQueryAsync(
            inlineQueryEventArgs.InlineQuery.Id,
            results,
            isPersonal: true,
            cacheTime: 0);
    }

    private static void BotOnChosenInlineResultReceived(object sender, ChosenInlineResultEventArgs chosenInlineResultEventArgs)
    {
        Console.WriteLine($"Received inline result: {chosenInlineResultEventArgs.ChosenInlineResult.ResultId}");
    }

    private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
    {
        Console.WriteLine("Received error: {0} — {1}",
            receiveErrorEventArgs.ApiRequestException.ErrorCode,
            receiveErrorEventArgs.ApiRequestException.Message);
    }

    public static string get(String url)
    {
        try
        {

            String r = "";
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
            httpWebRequest.Method = "GET";
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var responseStream = httpWebResponse.GetResponseStream();
            if (responseStream != null)
            {
                var streamReader = new StreamReader(responseStream);
                r = streamReader.ReadToEnd();
            }
            if (responseStream != null) responseStream.Close();
            //Console.WriteLine(r);
            return r;
        }
        catch (WebException ex)
        {
            return null;
        }
    }


}
