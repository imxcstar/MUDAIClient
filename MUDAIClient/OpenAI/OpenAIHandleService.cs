using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI.GPT3.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace MUDAIClient.OpenAI
{
    public class OpenAIHandleService
    {
        private OpenAIService? _openAIService;

        public OpenAIHandleService()
        {
        }

        public OpenAIHandleService(OpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        public void SetOpenAIService(OpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        public void HandPlayerCommand(string gameMessage, string command, Action<string> successCallBack, Action<string>? errorCallBack = null)
        {
            if (_openAIService == null)
            {
                errorCallBack?.Invoke("openAIService is null");
                return;
            }
            Task.Run(async () =>
            {
                var completionResult = await _openAIService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
                {
                    Messages = new List<ChatMessage>
                    {
                                                ChatMessage.FromSystem(@"你是一个把用户输入的自然语言转换成mud游戏指令的机器人，你的任务如下：
1、判断用户输入的可能是名字、账号或密码等，此类原样转换即可
2、判断用户输入的内容可能是命令信息，此类需要转换成mud游戏指令
3、如果用户输入的信息是需要原样转换的，但是此信息带有描述，则需要提取核心信息，进行转换输出。（比如：用户输入的是“我的名字：test”，则转换输出：test）
4、游戏的内容是你的判断依据
"),
                                                ChatMessage.FromUser("游戏内容：您的英文名字（要注册新人物请输入new。）："),
                                                ChatMessage.FromUser("用户输入：test"),
                                                ChatMessage.FromAssistant("以下是转换后的信息："),
                                                ChatMessage.FromAssistant("test"),
                                                ChatMessage.FromUser("游戏内容：您的密码是："),
                                                ChatMessage.FromUser("用户输入：123456"),
                                                ChatMessage.FromAssistant("以下是转换后的信息："),
                                                ChatMessage.FromAssistant("123456"),
                                                ChatMessage.FromUser("游戏内容：您现在的操作是什么？>"),
                                                ChatMessage.FromUser("用户输入：看一下那小狗"),
                                                ChatMessage.FromAssistant("以下是转换后的信息："),
                                                ChatMessage.FromAssistant("l dog"),
                                                ChatMessage.FromUser("用户输入：南"),
                                                ChatMessage.FromAssistant("以下是转换后的信息："),
                                                ChatMessage.FromAssistant("south"),
                                                ChatMessage.FromUser($"游戏内容：\r\n{string.Join("",gameMessage.Skip(gameMessage.Length>512?gameMessage.Length-512:gameMessage.Length))}"),
                                                ChatMessage.FromUser($"用户输入：\r\n{command}"),
                                                ChatMessage.FromAssistant("以下是转换后的信息："),
                    },
                    Model = Models.ChatGpt3_5Turbo,
                    MaxTokens = 1024,
                    Temperature = 0
                });
                if (completionResult.Successful)
                {
                    var ret = completionResult.Choices.FirstOrDefault()?.Message.Content;
                    if (ret == null)
                        return;
                    successCallBack.Invoke(ret);
                }
                else
                {
                    if (completionResult.Error == null)
                    {
                        errorCallBack?.Invoke("Unknown Error");
                        return;
                    }
                    errorCallBack?.Invoke($"{completionResult.Error.Code}: {completionResult.Error.Message}");
                }
            });
        }

        public async Task HandleGameMessage(string message, Action<string> successCallBack, Action<string>? errorCallBack = null)
        {
            if (_openAIService == null)
            {
                errorCallBack?.Invoke("openAIService is null");
                return;
            }

            try
            {
                await Task.Run(async () =>
                {
                    var completionResult = _openAIService.ChatCompletion.CreateCompletionAsStream(new ChatCompletionCreateRequest
                    {
                        Messages = new List<ChatMessage>
                        {
                            ChatMessage.FromSystem(@"你是一个规范格式化mud游戏内容的机器人，你的任务如下：
1、把mud游戏内容信息，提取玩家需要的核心内容，其它对玩家无关的内容不需要提取，进行格式化排版整理后输出
2、你不能输出跟上下文无关的信息，也不需要对内容进行扩展描述，不能对游戏内容进行解读等操作，该精简的内容就精简
3、精简内容不能丢失核心信息，比如一些npc，物品，场景，id信息等"),
                            ChatMessage.FromUser(@"侠客英雄传已经运行了一时四十九分五十五秒。
自一九九九年十一月二十八日起，侠客英雄传共有一百三十人次来访。
侠客英雄传目前共有八个注册玩家。
目前共有零位管理员、零位玩家在线上，以及一位使用者尝试连线中。
本MUD目前处于试运行阶段，有任何BUG均欢迎报告，我们将尽快给你答复，并按其做出相应奖励！！
您的英文名字："),
                            ChatMessage.FromAssistant("收到，以下是游戏内容信息的格式化排版整理："),
                            ChatMessage.FromAssistant(@"
游戏：侠客英雄传
在线玩家：0
请输入您的英文名字：
"),
                            ChatMessage.FromUser(@"请输入密码："),
                            ChatMessage.FromAssistant("收到，以下是游戏内容信息的格式化排版整理："),
                            ChatMessage.FromAssistant(@"请输入密码："),
                            ChatMessage.FromUser(@"重新连线完毕。"),
                            ChatMessage.FromAssistant("收到，以下是游戏内容信息的格式化排版整理："),
                            ChatMessage.FromAssistant(@"系统信息：重新连线完毕。"),
                            ChatMessage.FromUser(@"中央广场 - 
    这里是侠客城的正中心，一个很宽阔的广场，地面整齐地铺着大青石
板。一些武林侠士经常聚集在这里。广场中央是一座十数人高的汉白玉图
腾，上面刻看几个金色的大字“侠客城”(zi)。图腾周围的一片都是花儿
草儿，附近有几棵大榕树，盘根错节，据传已有千年的树龄，是这座城市
的历史见证。你可以看到四面都有来自各地的行人来来往往，人声鼎沸，
一派繁华景象。
    太阳正高挂在东方的天空中。
    天气非常晴朗。天空万里无云。一点风都没有。
    这里明显的出口是 west、east、north 和 south。
  中央广场留言板(Board) [ 15 张留言，9 张未读 ]
  武林盟主 梁大侠(Wuling mengzhu)"),
                            ChatMessage.FromAssistant("收到，以下是游戏内容信息的格式化排版整理："),
                            ChatMessage.FromAssistant(@"场景：中央广场：
- 场景描述：侠客城的正中心，地面铺着大青石板，中央有一座汉白玉图腾，周围是花草和大榕树，人来人往，繁华景象。
- 出口：西，东，北，南
- 场景单位：
    -中央广场留言板(Board) [ 15 张留言，9 张未读 ]
    -武林盟主 梁大侠(Wuling mengzhu)"),
                            ChatMessage.FromUser(message),
                            ChatMessage.FromAssistant("收到，以下是游戏内容信息的格式化排版整理：")
                        },
                        Model = Models.ChatGpt3_5Turbo,
                        MaxTokens = 1024,
                        Temperature = 0
                    });

                    await foreach (var completion in completionResult)
                    {
                        if (completion.Successful)
                        {
                            var ret = completion.Choices.FirstOrDefault()?.Message.Content;
                            if (!string.IsNullOrEmpty(ret))
                                successCallBack.Invoke(ret);
                        }
                        else
                        {
                            if (completion.Error == null)
                            {
                                errorCallBack?.Invoke("Unknown Error");
                                continue;
                            }
                            errorCallBack?.Invoke($"{completion.Error.Code}: {completion.Error.Message}");
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                errorCallBack?.Invoke(ex.Message);
            }
        }
    }
}
