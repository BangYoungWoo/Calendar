using System;


class Date
{
    //달력에 출력될 날짜
    public int year;
    public int month;
    //10간
    int tenStems;
    public string RealTenStem;
    public bool tenStemTrace;
    //12지
    int zodiac;
    public string RealZodiac;
    public bool zodiacTrance;
    //현재 날짜까지 계산할 날짜
    int startYear;
    int startMonth;
    int startDay;
    //달력에 입력할 배열의 인덱스 스텍
    int weekStack;
    int dayStack;
    //현재 날짜까지 계산하는 판별문
    bool searching;
    //이번달 달력에 날짜를 넣기 시작하는 판별문
    bool stackStart;
    //계산된 값을 넣을 달력
    public int[,] calendar = new int[6, 7];
    //정수로 된 달력의 값을 문자열화시켜 옮겨담아 출력할 진짜 달력
    public string[,] RealCalendar = new string[6, 7];

    public Date()
    {
        //현재 날짜, 오전or오후,시간, 분, 초 갱신
        DateTime startDay = DateTime.Now;
        //현재 시각 데이터 문자열화
        string strCup = startDay.ToString();
        //날짜 오전or오후 시간대 분리
        string[] YYMMDDAPHHMMSS = strCup.Split(new string[] { " " }, StringSplitOptions.None);
        //날짜대 분리
        string[] YYMMDD = YYMMDDAPHHMMSS[0].Split(new string[] { "-" }, StringSplitOptions.None);
        //년,월,일 분리
        year = Convert.ToInt32(YYMMDD[0]);
        month = Convert.ToInt32(YYMMDD[1]);
    }
    public void SearchToDay(int SearchYear, int SearchMonth, int SearchDay)
    {
        //날짜 검색 이전 모든 내역 초기화
        CalendarReset();

        while (searching)
        {
            //10간, 12지 마지막 번째 다음이 되면 처음으로 되돌림
            if (tenStems == (int)TenStems.Cycle)
                tenStems = (int)TenStems.Armor;
            if (zodiac == (int)Zodiac.Cycle)
                zodiac = (int)Zodiac.Mouse;

            //찾는 날이 발견되면 해당 달까지만 작동
            if (dayStack == 7)
                dayStack = 0;

            //년도, 달 같으면 캘린더에 일자 넣기 시작
            if (startYear == SearchYear &&
               startMonth == SearchMonth)
                stackStart = true;

            if (stackStart)
            {
                //입력한 달과 검색중인 달과 일치하지 않으면 해당 일자에 0을 넣음
                if (startMonth != SearchMonth)
                {
                    calendar[weekStack, dayStack] = 0;
                }
                //이외 제대로 된 날짜
                else calendar[weekStack, dayStack] = startDay;

                //토요일마다 다음주로 전환
                if (dayStack == 6)
                    weekStack++;
            }

            //캘린더 마지막날 검색 중단
            if (weekStack == 6 && dayStack == 6)
                searching = false;

            if (searching)
            {
                //다음날
                startDay++;
                //요일, 일 매칭
                dayStack++;
                //말일 다음날 리셋
                DayReset();
            }
        }

        //달력에 입력된 0숫자 제거
        ZeroDayRemove();
        //10간, 12지 문자 입력
        CharWrite();
        //판별값 조건에 따라 10간, 12지를 한글 or 한자 출력
        TenStemTrance();
        ZodiacTrance(); 
    }
    //이름값
    public void CalendarReset()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                RealCalendar[i, j] = string.Empty;
                calendar[i, j] = 0;
            }
        }
        startYear = 1918;
        startMonth = (int)Month.December;
        startDay = 29;
        stackStart = false;
        weekStack = 0;
        dayStack = 0;
        searching = true;
        RealTenStem = string.Empty;
        RealZodiac = string.Empty;
        tenStems = (int)TenStems.Thick;
        zodiac = (int)Zodiac.Holse;
    }
    public void ZeroDayRemove()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (calendar[i, j] > 0)
                    RealCalendar[i, j] += calendar[i, j];
                else
                    RealCalendar[i, j] = string.Empty;
            }
        }
    }
    private void DayReset()
    {
        //말일을 초일로 리셋
        switch (startMonth)
        {
            case (int)Month.January:
                if (startDay == (int)DayLast.JanuaryLastDay)
                    startDay = (int)DayLast.MonthFirstDay;
                break;
            case (int)Month.February:
                //윤년이 아니면 1일로
                if (startYear % (int)DayLast.LeapYear != 0 && startDay == (int)DayLast.FebruaryLastDay)
                    startDay = (int)DayLast.MonthFirstDay;
                //윤년이면 1일로
                else if (startYear % (int)DayLast.LeapYear == 0 && startDay == (int)DayLast.FebruaryLeap)
                    startDay = (int)DayLast.MonthFirstDay;
                break;
            case (int)Month.March:
                if (startDay == (int)DayLast.MarchLastDay)
                    startDay = (int)DayLast.MonthFirstDay;
                break;
            case (int)Month.April:
                if (startDay == (int)DayLast.AprilLastDay)
                    startDay = (int)DayLast.MonthFirstDay;
                break;
            case (int)Month.May:
                if (startDay == (int)DayLast.MayLastDay)
                    startDay = (int)DayLast.MonthFirstDay;
                break;
            case (int)Month.June:
                if (startDay == (int)DayLast.JuneLastDay)
                    startDay = (int)DayLast.MonthFirstDay;
                break;
            case (int)Month.July:
                if (startDay == (int)DayLast.JulyLastDay)
                    startDay = (int)DayLast.MonthFirstDay;
                break;
            case (int)Month.August:
                if (startDay == (int)DayLast.AugustLastDay)
                    startDay = (int)DayLast.MonthFirstDay;
                break;
            case (int)Month.September:
                if (startDay == (int)DayLast.SeptemberLastDay)
                    startDay = (int)DayLast.MonthFirstDay;
                break;
            case (int)Month.October:
                if (startDay == (int)DayLast.OctoberLastDay)
                    startDay = (int)DayLast.MonthFirstDay;
                break;
            case (int)Month.November:
                if (startDay == (int)DayLast.NovemberLastDay)
                    startDay = (int)DayLast.MonthFirstDay;
                break;
            case (int)Month.December:
                if (startDay == (int)DayLast.DecemberLastDay)
                {
                    startDay = (int)DayLast.MonthFirstDay;
                    startYear++;
                    tenStems++;
                    zodiac++;
                }
                break;
        }
        if (startMonth != (int)Month.December && startDay == (int)DayLast.MonthFirstDay)
            startMonth++;
        else if (startMonth == (int)Month.December && startDay == (int)DayLast.MonthFirstDay)
            startMonth = (int)Month.January;
    }
    public void MonthControl()
    {
        if (month == (int)Month.NextYear)
        {
            month = (int)Month.January;
            year++;
        }
        if (month == (int)Month.BeforeYear)
        {
            month = (int)Month.December;
            year--;
        }
    }
    public void CharWrite()
    {
        switch (tenStems)
        {
            case (int)TenStems.Armor:
                RealTenStem = "甲";
                break;
            case (int)TenStems.Second:
                RealTenStem = "乙";
                break;
            case (int)TenStems.South:
                RealTenStem = "丙";
                break;
            case (int)TenStems.Worker:
                RealTenStem = "丁";
                break;
            case (int)TenStems.Thick:
                RealTenStem = "戊";
                break;
            case (int)TenStems.Body:
                RealTenStem = "己";
                break;
            case (int)TenStems.Years:
                RealTenStem = "庚";
                break;
            case (int)TenStems.Spicy:
                RealTenStem = "辛";
                break;
            case (int)TenStems.Noth:
                RealTenStem = "壬";
                break;
            case (int)TenStems.Count:
                RealTenStem = "癸";
                break;
        }

        switch (zodiac)
        {
            case (int)Zodiac.Mouse:
                RealZodiac = "子";
                break;
            case (int)Zodiac.bull:
                RealZodiac = "丑";
                break;
            case (int)Zodiac.Tiger:
                RealZodiac = "寅";
                break;
            case (int)Zodiac.Rabbit:
                RealZodiac = "卯";
                break;
            case (int)Zodiac.Dragon:
                RealZodiac = "辰";
                break;
            case (int)Zodiac.Snake:
                RealZodiac = "巳";
                break;
            case (int)Zodiac.Holse:
                RealZodiac = "午";
                break;
            case (int)Zodiac.Sheep:
                RealZodiac = "未";
                break;
            case (int)Zodiac.Monkey:
                RealZodiac = "申";
                break;
            case (int)Zodiac.Hen:
                RealZodiac = "酉";
                break;
            case (int)Zodiac.Dog:
                RealZodiac = "戌";
                break;
            case (int)Zodiac.Pig:
                RealZodiac = "亥";
                break;
        }
    }
    public void TenStemTrance()
    {
        if (tenStemTrace == true)
            switch (RealTenStem)
            {
                case "甲":
                    RealTenStem = "갑";
                    break;
                case "乙":
                    RealTenStem = "을";
                    break;
                case "丙":
                    RealTenStem = "병";
                    break;
                case "丁":
                    RealTenStem = "정";
                    break;
                case "戊":
                    RealTenStem = "무";
                    break;
                case "己":
                    RealTenStem = "기";
                    break;
                case "庚":
                    RealTenStem = "경";
                    break;
                case "辛":
                    RealTenStem = "신";
                    break;
                case "壬":
                    RealTenStem = "임";
                    break;
                case "癸":
                    RealTenStem = "계";
                    break;
            }
        else if (tenStemTrace == false)
            switch (RealTenStem)
            {
                case "갑":
                    RealTenStem = "甲";
                    break;
                case "을":
                    RealTenStem = "乙";
                    break;
                case "병":
                    RealTenStem = "丙";
                    break;
                case "정":
                    RealTenStem = "戊";
                    break;
                case "무":
                    RealTenStem = "戊";
                    break;
                case "기":
                    RealTenStem = "己";
                    break;
                case "경":
                    RealTenStem = "庚";
                    break;
                case "신":
                    RealTenStem = "辛";
                    break;
                case "임":
                    RealTenStem = "壬";
                    break;
                case "계":
                    RealTenStem = "癸";
                    break;
            }

    }
    public void ZodiacTrance()
    {
        if (zodiacTrance == true)
            switch (RealZodiac)
            {
                case "子":
                    RealZodiac = "자";
                    break;
                case "丑":
                    RealZodiac = "축";
                    break;
                case "寅":
                    RealZodiac = "인";
                    break;
                case "卯":
                    RealZodiac = "묘";
                    break;
                case "辰":
                    RealZodiac = "진";
                    break;
                case "巳":
                    RealZodiac = "사";
                    break;
                case "午":
                    RealZodiac = "오";
                    break;
                case "未":
                    RealZodiac = "미";
                    break;
                case "申":
                    RealZodiac = "신";
                    break;
                case "酉":
                    RealZodiac = "유";
                    break;
                case "戌":
                    RealZodiac = "술";
                    break;
                case "亥":
                    RealZodiac = "해";
                    break;
            }
        else if (zodiacTrance == false)
            switch (RealZodiac)
            {
                case "자":
                    RealZodiac = "子";
                    break;
                case "축":
                    RealZodiac = "丑";
                    break;
                case "인":
                    RealZodiac = "寅";
                    break;
                case "묘":
                    RealZodiac = "卯";
                    break;
                case "진":
                    RealZodiac = "辰";
                    break;
                case "사":
                    RealZodiac = "巳";
                    break;
                case "오":
                    RealZodiac = "午";
                    break;
                case "미":
                    RealZodiac = "未";
                    break;
                case "신":
                    RealZodiac = "申";
                    break;
                case "유":
                    RealZodiac = "酉";
                    break;
                case "술":
                    RealZodiac = "戌";
                    break;
                case "해":
                    RealZodiac = "亥";
                    break;
            }
    }
}

