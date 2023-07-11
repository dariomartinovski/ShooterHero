# ShooterHero

Unity 2D game by: Dario Martinovski
---

### 1. Опис на апликацијата
Името на играта е „Shooter Hero“, и таа изгледа како подолу поставените слики. Играта има еден главен херој, кој може да пука и да собира поени. Поените ги добива преку „убивање“ на противниците, кои се појавуваат од сите страни и одат накај херојот, интервалот на нивното појавување се намалува секоја измината секунда. Исто така херојот има пет животи, кои му се намалуваат за еден кога нема да успее да убие некој противник и тој ќе се удри во херојот. Играта има два можни завршетоци, при победа или при загуба. Победа се случува кога херојот ќе ги преживее десетте минути, со било колку останати животи, а играта се губи доколку животите се намалат до нула. \
\
  <img src="https://github.com/dariomartinovski/ShooterHero/assets/80409852/6a640120-d306-4ad4-a05c-e21ea1081350" alt="Start screen image" style="width: 440px;">
  <img src="https://github.com/dariomartinovski/ShooterHero/assets/80409852/5bdc3a25-2ec1-4d5f-bd30-89d1db5644d5" alt="Gameplay image" style="width: 440px;">
##
### 2. Упатство за користењe
#### 2.1 Почеток на играта
Играта започнува т.ш. се вклучува почетниот екран, Слика 1 погоре. Потоа од таму можеме да ја исклучиме играта со клик на копчето „Exit Game“, или да започнеме со играта со клик на копчето „Start Game“. Исто така на почетниот екран се испишани моменталните најдобри поени. \
Со клик на копчето „Start Game“ започнува играта, а со тоа и појавувањето на противниците, како и откуцувањето на тајмерот, кој започнува да откуцува надоле од 10 минути, прикажан во горниот десен агол. Во горниот лев агол ни се прикажани моменталните животи, секоја игра започнува со пет животи.
#### 2.2 Движење на херојот
Херојот можеме да го движиме преку тестатура, преку копчињата W, A, S и D, или пак преку стрелките. 
#### 2.3 Пукање со херојот
Херојот има пушка која го следи движењето на глувчето. Со лев клик на глувчето можеме да истреламе куршум, со држење на левиот клик се истрелуваат куршуми непрекинато, со тоа што има предодредена рата на пукање во секунда. Кога некој куршум ќе погоди некој противник, противникот се уништува во тој момент, исто како и куршумот.
#### 2.4 Појавување на противници
Противниците се појавуваат на секои 5 секунди од сите четири страни истовремено, времето на појавување се намалува на секој а секунда за 0.3 секунди, значи од 9та до 10та минута противниците ќе се појавуваат на секои 5 секунди, па потоа од 8сма до 9та минута ќе се појавуваат на секои 4.7 секунди и т.н. Противниците може да бидат убиени од еден куршум, пришто даваат по 10 поени, или може да се судрат со херојот пришто му одземаат еден живот.
#### 2.5 Пауза
Играта може да се паузира преку клик на копчето „Escape“ од тестатурата, пришто се појавува Pause менито. Pause менито е составено од копче „Resume Game“, „New Game“ и „Exit Game“. Играта може да ја продолжиме преку клик на копчето „Resume Game“ или преку повторен клик на копчето „Есцапе“ од тестатура. Нова игра може да започнеме преку клик на копчето „New Game“, пришто се губи целиот напредок. Истот така има и копче за исклучување на играта.
#### 2.4 Победа
Позитивниот исход на играта е при победа, што се случува кога тајмерот ќе пристигне до 0, а херојот има останати еден или повеќе животи. Ако моменталните поени се поголеми од најголемите(high score), тогаш тие се зачувуваат.
#### 2.5 Загуба
Негативниот исход на играта се случува кога херојот ќе остане без ниту еден живот, и играта прекинува. Ако моменталните поени се поголеми од најголемите(high score), тогаш тие се зачувуваат.
##
### 3. Претставување на проблемот
### 3.1 Податочни структури
Главните податочни структури во оваа апликација се класи, листи, основните податочни типови float, integer, bool, како и Unity специфичните типови како што се GameObject и Transform.
```c#
public class LogicScript : MonoBehaviour
{
    public int CurretnLives = 5;
    public int Score = 0;
    private bool GamePaused = false;
    private bool GameActive = false;

    public Text ScoreDisplay;
    public Text TotalScore;
    public Text EnemiesKilled;
    public Text HighScore;
    public Text StartScreenHighScore;

    public GameObject GameFinishedScreen;
    public GameObject gameWonScreen;
    public GameObject gameLostScreen;
    public GameObject gamePausedScreen;
    public GameObject startGameScreen;
    private bool SomethingDispalyed = false;

    public void Start() {
        PlayerPrefs.SetInt("HighScore", Math.Max(PlayerPrefs.GetInt("HighScore"), 0));
        SetKillsCounter();
        StartScreenHighScore.text = "High score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameActive)
        {
            //pause game
            if (GamePaused)
            {
                gamePausedScreen.SetActive(false);
            }
            else
            {
                gamePausedScreen.SetActive(true);
            }
            GamePaused = !GamePaused;
        }
    }

    public void TakeDamage(int num = 1) {
        CurretnLives -= num;
        ScoreDisplay.text = CurretnLives.ToString();
    }

    public void Hit() {
        Score++;
        SetKillsCounter();
    }

    public void SetKillsCounter() {
        ScoreDisplay.text = "Score: " + Score.ToString();
    }

    public void GameOver()
    {
        if (!SomethingDispalyed)
        {
            gameLostScreen.SetActive(true);
            DisplayInfo();
            SomethingDispalyed = true;
        }
    }

    public void GameWon()
    {
        if (!SomethingDispalyed)
        {
            gameWonScreen.SetActive(true);
            DisplayInfo();
            SomethingDispalyed = true;
        }
    }

    public bool PausedGame() {
        //make game paused screen
        return GamePaused;
    }

    public void ResumeGame() {
        if (GamePaused)
        {
            gamePausedScreen.SetActive(false);
        }
        else
        {
            gamePausedScreen.SetActive(true);
        }
        GamePaused = !GamePaused;
    }

    public void DisplayInfo()
    {
        GameActive = false;
        GameFinishedScreen.SetActive(true);

        // Update high score
        PlayerPrefs.SetInt("HighScore", Math.Max(PlayerPrefs.GetInt("HighScore"), Score * 10));
        
        TotalScore.text = "Score: " + (Score * 10).ToString();
        EnemiesKilled.text = "Total enemies killed: " + Score.ToString();
        HighScore.text = "High score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void RestartGame() {
        GameActive = false;
        startGameScreen.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
```
Ова е кодот на LogicScript класата. \
\
Најпрво се чуваат променливи за бројот на моментални животи(5), потоа се чува променлива за поените. GamePaused променелнивата ни кажува дали играта е паузирана, додека GameActive, дали е завршена играта или не. \
Потоа чувам повеќе променливи од тип Text, кој е специфичен за Unity, и таа променлива ја добива вредноста преку drag-and-drop на соодветната Text компонента од Unity едиторот. \
Наредно се чуваат GameObject променливи, кои на сличен начин како претходната Text компонента, вредност добиваат преку drag-and-drop во Unity едиторот. Тие исто така може да добијат вредност преку код, со земање на компонентата со соодветен таг. \
\
Најпрво кога се вчитува скриптата се извршува **Start** функцијата, која се состои од три линии код. Најпрво се зачувува PlayerPref HighScore, со кој може да симулираме Highscore функционалност, таа информација се зачувува локално на нашиот компјтуер. Се користи Math max со 0, бидејќи може да не постои претходна игра. Наредните линии само менуваат text полиња соодветни, за поени и најголеми поени на почетниот екран. \
\
Функција која се извршува континуирано е методот **Update**, каде слушаме за клик на копчето *Escape* од тестатура, и ако е кликнато истото ја менуваме промелнивата GamePaused, која носи соодветни последици. 
\
**TakeDamage** е функција која ја повикуваме од друга скрипта, кога ќе настане колизија помеѓу херојот и неговите противници. Бројот на одземани животи може да се менува, default вредност е 1. \
\
**Hit** фунцијата е функција која го зголемува бројот на поени на играчот и таа се повикува кога некој куршум ќе се удри во противникот.
```c#
void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.CompareTag("Enemy"))
        {
            Destroy(Other.gameObject);
            Destroy(gameObject);
            Logic.Hit();
        }
    }
```
Вака изгледа функцијата, од каде се повикува методот Hit. OnTriggerEnter2D е специјална функција од Unity, која се повикува кога моменталниот објект ќе се судри со друг објект, и тој друг објект се наоѓа во промелнивата Collider2D Other. Со Destroy се уништува објектот со кој е направена колизија и моменталниот објект. \
\
**GameOver** функцијата е слична со **GameWon** функцијата. Најпрво во функцијата се проверува дали веќе има нешто прикажано на екран, ако има не прави ништо, а ако нема тогаш стави го објектот gameOverScreen да биде активен, кој на почетокот во UnityEditor-от беше ставен на неактивен, односно да не се гледа. Потоа само се менуваат некои текст полиња во **DisplayInfo** функцијата.

### 4. Дополнителни слики од играта
  <img src="https://github.com/dariomartinovski/ShooterHero/assets/80409852/64c1693a-6738-46b8-a5f1-328c93e29e4c" alt="Почетен екран" style="width: 440px;">
  <img src="https://github.com/dariomartinovski/ShooterHero/assets/80409852/0b4276bc-6503-4c21-b54d-1df537e1c71a" alt="Почетен екран" style="width: 440px;">
   <img src="https://github.com/dariomartinovski/ShooterHero/assets/80409852/6fc0a889-265c-4a0e-91c7-fa813b8c93c5" alt="Почетен екран" style="width: 440px;">
   <img src="https://github.com/dariomartinovski/ShooterHero/assets/80409852/f80dfd53-922a-4492-bdae-7bf95690e6f9" alt="Почетен екран" style="width: 440px;">
  <img src="https://github.com/dariomartinovski/ShooterHero/assets/80409852/903d4d0b-18f8-4d99-a44c-a78832943ad5" alt="Почетен екран" style="width: 440px;">
  <img src="https://github.com/dariomartinovski/ShooterHero/assets/80409852/5c2fa152-732d-40a9-af94-48ae6b01d0c4" alt="Почетен екран" style="width: 440px;"> 
  
---

**Целиот изворен код, како и exe датотеката се наоѓаат во branch-от master.
