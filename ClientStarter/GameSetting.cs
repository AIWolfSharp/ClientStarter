//
// GameSetting.cs
//
// Copyright 2016 OTSUKI Takashi
// SPDX-License-Identifier: Apache-2.0
//

using AIWolf.Lib;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AIWolf.Client
{
#if JHELP
    /// <summary>
    /// ゲームの設定
    /// </summary>
#else
    /// <summary>
    /// The settings of the game.
    /// </summary>
#endif
    public class GameSetting : IGameSetting
    {
#if JHELP
        /// <summary>
        /// 各役職の人数
        /// </summary>
#else
        /// <summary>
        /// The number of each role.
        /// </summary>
#endif
        public IDictionary<Role, int> RoleNumMap { get; }

#if JHELP
        /// <summary>
        /// １日に許される最大会話回数
        /// </summary>
#else
        /// <summary>
        /// The maximum number of talks.
        /// </summary>
#endif
        public int MaxTalk { get; }

#if JHELP
        /// <summary>
        /// １日に許される最大会話ターン数
        /// </summary>
#else
        /// <summary>
        /// The maximum number of turns of talk.
        /// </summary>
#endif
        public int MaxTalkTurn { get; }

#if JHELP
        /// <summary>
        /// １日に許される最大囁き回数
        /// </summary>
#else
        /// <summary>
        /// The maximum number of whispers a day.
        /// </summary>
#endif
        public int MaxWhisper { get; }

#if JHELP
        /// <summary>
        /// １日に許される最大囁きターン数
        /// </summary>
#else
        /// <summary>
        /// The maximum number of turns of whisper.
        /// </summary>
#endif
        public int MaxWhisperTurn { get; }

#if JHELP
        /// <summary>
        /// 連続スキップの最大許容長
        /// </summary>
#else
        /// <summary>
        /// The maximum permissible length of the succession of SKIPs.
        /// </summary>
#endif
        public int MaxSkip { get; }

#if JHELP
        /// <summary>
        /// 最大再投票回数
        /// </summary>
#else
        /// <summary>
        /// The maximum number of revotes.
        /// </summary>
#endif
        public int MaxRevote { get; }

#if JHELP
        /// <summary>
        /// 最大再襲撃投票回数
        /// </summary>
#else
        /// <summary>
        /// The maximum number of revotes for attack.
        /// </summary>
#endif
        public int MaxAttackRevote { get; }

#if JHELP
        /// <summary>
        /// 誰も襲撃しないことを許すか否か
        /// </summary>
#else
        /// <summary>
        /// Whether or not the game permit to attack no one.
        /// </summary>
#endif
        public bool EnableNoAttack { get; }

#if JHELP
        /// <summary>
        /// 誰が誰に投票したかわかるか否か
        /// </summary>
#else
        /// <summary>
        /// Whether or not agent can see who vote to who.
        /// </summary>
#endif
        public bool VoteVisible { get; }

#if JHELP
        /// <summary>
        /// 初日に投票があるか否か
        /// </summary>
#else
        /// <summary>
        /// Whether or not there is vote on the first day.
        /// </summary>
#endif
        public bool VotableOnFirstDay { get; }

#if JHELP
        /// <summary>
        /// 同票数の場合追放なしとするか否か
        /// </summary>
#else
        /// <summary>
        /// Whether or not executing nobody is allowed.
        /// </summary>
#endif
        public bool EnableNoExecution { get; }

#if JHELP
        /// <summary>
        /// 初日にトークがあるか否か
        /// </summary>
#else
        /// <summary>
        /// Whether or not there are talks on the first day.
        /// </summary>
#endif
        public bool TalkOnFirstDay { get; }

#if JHELP
        /// <summary>
        /// 発話文字列のチェックをするか否か
        /// </summary>
#else
        /// <summary>
        /// Whether or not the uttered text is validated.
        /// </summary>
#endif
        public bool ValidateUtterance { get; }

#if JHELP
        /// <summary>
        /// 再襲撃投票前に囁きがあるか否か
        /// </summary>
#else
        /// <summary>
        /// Whether or not werewolf can whisper before the revote for attack.
        /// </summary>
#endif
        public bool WhisperBeforeRevote { get; }

#if JHELP
        /// <summary>
        /// 乱数の種
        /// </summary>
#else
        /// <summary>
        /// The random seed.
        /// </summary>
#endif
        public long RandomSeed { get; }

#if JHELP
        /// <summary>
        /// リクエスト応答時間の上限
        /// </summary>
#else
        /// <summary>
        /// The upper limit for the response time to the request.
        /// </summary>
#endif
        public int TimeLimit { get; }

#if JHELP
        /// <summary>
        /// プレイヤーの数
        /// </summary>
#else
        /// <summary>
        /// The number of players.
        /// </summary>
#endif
        public int PlayerNum { get; }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        [JsonConstructor]
        GameSetting(Dictionary<Role, int> roleNumMap, int maxTalk, int maxTalkTurn, int maxWhisper,
            int maxWhisperTurn, int maxSkip, int maxRevote, int maxAttackRevote, bool enableNoAttack,
            bool voteVisible, bool votableInFirstDay, bool enableNoExecution, bool talkOnFirstDay,
            bool validateUtterance, bool whisperBeforeRevote, long randomSeed, int timeLimit)
        {
            RoleNumMap = roleNumMap == null ? new ReadOnlyDictionary<Role, int>(new Dictionary<Role, int>()) : new ReadOnlyDictionary<Role, int>(roleNumMap);
            MaxTalk = maxTalk;
            MaxTalkTurn = maxTalkTurn;
            MaxWhisper = maxWhisper;
            MaxWhisperTurn = maxWhisperTurn;
            MaxSkip = maxSkip;
            MaxRevote = maxRevote;
            MaxAttackRevote = maxAttackRevote;
            EnableNoAttack = enableNoAttack;
            VoteVisible = voteVisible;
            VotableOnFirstDay = votableInFirstDay;
            EnableNoExecution = enableNoExecution;
            TalkOnFirstDay = talkOnFirstDay;
            ValidateUtterance = validateUtterance;
            WhisperBeforeRevote = whisperBeforeRevote;
            RandomSeed = randomSeed;
            TimeLimit = timeLimit;
            PlayerNum = RoleNumMap.Values.Sum();
        }
    }
}
