TG_bot_emulator is a .NET WinFrom app that emulates the behaviour of the telegram webhook server calling your bot api.
It allows to use the custom telegram authentication header (X_Telegram_...) and to emulate more users interacting with your bot.
Designed to work with a php coded bot it include the option to enable XDebug by setting the XDEBUG_SESSION cookie in the request made to the bot endpoint.
