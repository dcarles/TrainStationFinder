using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainStationFinder.DataStructures;

namespace TrainStationFinder.Test
{
    [TestClass]
    public abstract class BaseTrieTest
    {
        protected ITrie<int> Trie { get; private set; }

        [TestInitialize]
        public virtual void Setup()
        {
            Trie = CreateTrie();
            for (int i = 0; i < Words40.Length; i++)
            {
                Trie.Add(Words40[i], i);
            }
        }

        protected abstract ITrie<int> CreateTrie();

        public string[] Words40 = new[] {
                                            "daubreelite",
                                            "daubingly",
                                            "daubingly",
                                            "phycochromaceous",
                                            "phycochromaceae",
                                            "phycite",
                                            "athymic",
                                            "athwarthawse",
                                            "athrotaxis",
                                            "unaccorded",
                                            "unaccordant",
                                            "unaccord",
                                            "kokoona",
                                            "koko",
                                            "koklas",
                                            "s",
                                            "flexibilty",
                                            "flexanimous",
                                            "collochemistry",
                                            "collochemistry",
                                            "collocationable",
                                            "capomo",
                                            "capoc",
                                            "capoc",
                                            "ungivingness",
                                            "ungiveable",
                                            "ungive",
                                            "prestandard",
                                            "prestandard",
                                            "prestabilism",
                                            "megalocornea",
                                            "megalocephalia",
                                            "megalocephalia",
                                            "afaced",
                                            "aettekees",
                                            "aetites",
                                            "comolecule",
                                            "comodato",
                                            "comodato",
                                            "cognoscibility"
                                        };

       

        [TestMethod]
        public void ExhaustiveAddTimeMeasurement()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            ITrie<int> trie = CreateTrie();
            foreach (var phrase in Words40)
            {
                trie.Add(phrase, phrase.GetHashCode());
            }

            stopwatch.Stop();
            Console.WriteLine("Time: {0} milliseconds", stopwatch.Elapsed.TotalMilliseconds);
        }

        public string[] LongPhrases40 = new[] {
                                                  "enterfeatnanocephalousssanapaiteadullamitesorchidologiessphenomandibularunremandedmeechersevererszamaforegamelaundsconelikesphalmaphylloptosiselvishvyproverbiologistdouanesdispensationalismapotypetearsheetsmesodisilicicnoncorruptnessheliotroperjinnywinkunrecurrent",
                                                  "scourwayproimmunityunstonetutoriatepreauditorydeaconaldishwipinginstillatorpardaosdespondentnessbourreaunonponderositysubconicquiniblemowtnonrecitationticchenreburnishnonexecutionsforfaulterflaughteringmausolespermysallokinesisescribientesbauckiehomopauseoverinfluence",
                                                  "noncontinuableprostascokemantelautomaticallydarnixsnowslipssubgoalcaddopostencephalondilutelyunrulablekilanalmacenistaangustateembryoctonychunneredlingismsoverdignifiedsparsonsitesubaqueansupercatholicallysprecounselmicrodistillationdisrestorecondensednesspredirectpinipicrin",
                                                  "unpredaciousnesschiarooscurossalfinrectigradeliverberryimpallupanayanodiflorousreadjourningrillettesaxeassoilzieingfruitwomanendonuclearunadventurousnesserinlacworksbandaiteparchableryukyuannondeformedanomitevolvocaceousreawaretiburtineunviolinedcuselitesawman",
                                                  "octavianporencephaliamirabilisesagrypnodefichtelitestylionindusiformacanthonhandspansunglospectrobolometerminisedananimadversivenesstrilliaceousoveytogetherhoodschoolgirlismnonmelodramaticallyssidiondawneredsubsphericpleuropedaloverlockingsamoritedendroclimatologiessyinstantiliquoracataposis",
                                                  "overdelicatenesskischensizeablenessseptomaxillarychumpishbelanderfallageantipragmaticismagranulocyticmechanalnoneasternepimyocardialbegoredretreatingnessfourquinecavilingnessradiestheticpolymixiidmelanotekitecacurunweepinghechtsactinostlimburgitesnonsubmergibilitysawbwaadddaunattractablewitherweightbacteriopurpurin",
                                                  "concatervateinogenesissgyrographembiotocidaeinguinodyniasfemorisrewishnonballotingoxidoreductionradiomuscularnoncurtailingsentogenousunrefundingrotavatorsuneathsflexibiltyunconsiderableszinkificationsnorseleruninstructiblesecchjuckholluschickslabellate",
                                                  "banintraligamentousargononunresumptivefinancistcentrarchidfumisteryserragemonseignevrunfoolishnessmahajunleatherfishesunfattenunsoothingsethylthioethanesuperrespectablesconsolanparcimoniesadenousblinterpedagogerybinoosphradiumconformatorsanisylflambageacquaintant",
                                                  "voicebandhuamuchilarticulabilitygiornatatelightlyingdealkylatepostbulbarosteotrophydiscommissioningcalombapoyntingvectionmacrosomiaimpolarilymetapoliticbiaswisebeedgedparafloccularitcheoglansolepieceladylintywhiteuncoherentlycoprophilismpiaclekarachivoglitespeculativismupbboreinterequinoctialbubbleless",
                                                  "sesoenteritismormaorshipmislyunpromiscuouslybescribblinghypopetalypennyfeenonobscurityhayliftpietosoessentializationflappetapparailsanticoagulatorprenominicaldrymouthspolymetamericmonariobelonosphaeritedwaiblesnonconsumptivelypapaiabeforenesscorkmakermacrosplanchnicundiagrammaticallymaxostoma",
                                                  "lasiocampidprunetincoventrybrigandishsuperacidityinterlucatenilometerveilednesslivishlyimprecatorilyrustfulmucroniformavelongeassociatorscleisteschylocystperithelialcapellaneprisiadkahypothetistgonotocontoariotomyssamidoazoattemperatorphthirusvellenagetriticalnessesthylose",
                                                  "unexcoriatedunimpressionabilityradiotropicbaronizedunfalcatedunretractedbayheadcoracocostaldovefloweroverbravenotopteridquadrinomicalsubdolouslyexhalatesceleratesperiareumcondensedlyoverpuissantlyhumanitymongermanucodemontrossaprilsilicoferruginousnpfxcaumstonetrebletreehyenanchinextraregularlybecommasemipathologically",
                                                  "sherryvalliesnonmonarchallysovereasinessmesocoelesubgenitalsouserworsementchondrectomydestinismavidyalysosomallyuncircumlocutoryboardysugescentpimolasciosophistarretezconscientisationleatmensanthroposociologistphyllobranchiatelonelihoodinteressortortilclintonchuradaunsatiabilityantitemperance",
                                                  "palimpsetsubmontagnebicornutemucoflocculentsallactiteparagonimiasisdreckiersubtotemunnormalnesssupersensitisercorruptednessluskschangarinemendableanthropoclimatologycobaltocyanicssacalinenondeficientcarcasslessfrustulumboliviansprepsychotictidelessnessrhyotaxiticundermuslinscurtaxepanlogist",
                                                  "precultureploughjoggersbodilizephysiologueerethizontidaehistoplasminlanchowsstatutumamphophilnondeprivationelectromotionspanpolismretrorenalpentadecagonmuscosenessarmoraciahippocastanaceousrecessorndebelelayshipmagnetolysisunhandselledfraudlessnessreevasionllerphytochemicalsbefan",
                                                  "caddiingunludicroussdiscanderingfindyssheemraadnonglucosidalbuggesssscotographyinfoldmentunpredictivelymullerianphoenicochroitearcanenessestoxiinfectiousayacahuitecesserscadastrationleucocytolysesperistrumoustextiferousunbemoanedcolloxylindevauntpergelisolcounterinteresthala",
                                                  "odoriphoreunfacetiousnessstauropegiadermatolysissbodypaintsalligatoridaeuntimorouslyjimsonpaintproofeylupwrapsunresignedlyprealludeunvisiblybulbotubermultititularunverbosenessgastrolatrouseelwrackstemplarlikenesssmysophiliaurushicqurangrasswidowhoodcyanuricheathenriess",
                                                  "weeshnonmischievousnesscitronciruscungeboiorthopyramidsourjackunsortcompanionizingesthesiometricinshiningchrysopeeanacrogynaeundestroyableproletarizationnunciustephromyeliticmevingpresubstitutiondecipiumunmachineableapomecometrysacraryprecanonicaltuboovarianbemonstersreedeoophoromalaciaselectrographitewaltrot",
                                                  "spacinessesfarmholdpyrocollodiontalterlamentationalattendresscakersleyinginterirrigationtransdermicaddlementsunshameablydihydrogensclairsentientdesonationunpiouslypteropogonscalfhoodduodramaswoolulosekenogeneticavailmentendotropictrymsfeebleheartedbounceablys",
                                                  "dispendiouslypostfeministsunicursalityflaggellaparavaginitistroussheteroxenousawardmentequangularmycoplasmatacaearomanipugliaflavorsomenesshemiteriaungraphicboltelnonextensionautocombustiblerhizomatictruismaticsketchabilitiestrilinoleateindazolecanotierscombercaryopterisesflattyfluoratesinecureshipcolocasia",
                                                  "cubiconetechnopsychologyprewarrantspostcommissureimpersonatrixsunoriginativewhafaboutfetoplacentaltridecenetransmigrationistslimnographmescalismsitalianoctachronousimproficiencypreeffectmyotrophyvaleraldehydesapskullsubjectileoligoprotheticdollfacebedotehydroscopistexpressorstowsenonswearermisregulating",
                                                  "palpigerousarchimperialistgangesbitterlessfrankfortsaikuchisemivitalquinquiliteralodorometerbandboxicaloverquicklybedinmargarateacetlaunderopinionmassednessunfrettyruntgenizingcyanophycinshadelessnessplaymongerstyrolstrophanhinlipopexiainterclericalfordablenessmakeshiftinesssfootpaddery",
                                                  "blatherydisunifysnonforeignesspurpartsulphocarbamideoutferrethardockcoevolvedcoevolvesnondemonstrativenessnonreparationpetrolizedunvitrescentunneareduncentralcleronomyroadstonebritishismdispassionedsundescriptivenesshydrogalvanicautoplasmotherapyhoordingredocketingunwreckedenfoldennonbankableprimevityunetymologically",
                                                  "paraplastinovermotorglaikitnesseskingrowmesiolingualthackoorcrossbeakoutpraisedsenaitecryometryherschelbutsudanseparatoriesdiscoplacentalianpreinsulatechoristryprincipestrichophytiaundislodgeableextratabularpreemployercouadiaphanyeventognathousintercirculatingscribbliestcobblerlessantrinsubministrantrockish",
                                                  "outfledattaccopremadnessempiriologicaluneradicateduntautologicallygantonoleocystmstantiliberalistvasemakingcocklighthydroxydehydrocorticosteroneanoscopetartagostackhousiaceousparanuclearterminizepurplinessorepearchfouetsinterdistinguishpanarchyjnanendriyaepirogeneticlateroversionidicantiphthisicalambulancingregidor",
                                                  "pyroxylenechararasseparatedlyanachronismaticalpicroerythrinfaninmesostomidnondespoticallygilgameshrecompetitionteredinidaebuteonineisosterismtranshumanizegasboatnoctambulesuperplausiblycossyritelingtowpalaebiologistschronosemicglossoplegiahypoalkalineendoaortitislushiercreammakermonosemicestocadawoilienocardia",
                                                  "pamplegiaepikeianonperceptiblesimmeringlyhydrocaulussuresbykathaguitermanitelamnectomyoutmalaproppedhemiramphinebeneplacitnonsilicatewelkeremovelesscorrelativismwitchbroomrisslebirkiestshemitepandariccroatiaphotoepinasticmacrosplanchnicornationinsensingsorroanoncumbrousparatitlesmahdism",
                                                  "strouthiocameliancyanochroianonimpeachablesubtrochantericbudgypailettepaininglypindanonexemptionmonoplasmaticbiliprasinnoncelestialshithertolyleneenrobementastronsmyrnioteingeniosepihyalcytococciseignioralcondiddlementditremidundermanagerkidgierpootersbetrunkdeparliamentvidkids",
                                                  "aponogetonaceousunconsultativesvirificshrinkergchileansoutshovingrhombiformtricompoundcapotenpachangaigniformdespairfulnesssprintlinebetafitelethargicalnesssericiculturescrassilingualnonadjacenciessketoketenevellincherheterizeelectrocataphoreticarchaeohippusalsweillfouetsundrossinessreduviidae",
                                                  "unsmirkingnonamotionlaryngismalnonsynodicallyleysingdamaskinesmookspondilbishoplessbritishersnoldaraireslaccicprivilegerswangynonsingularitiesnoucheopisthographicalsubtransverselyweirdlessnessubermenschsrehypothecateincorporealizepractitioneryuninucleatedinvertibratesafenerrelayer",
                                                  "calamaroidfarcemeatsubsulfatecolluncoredeemerbeslaveredunshammedprocellosedarksummonocondyliangollanspolarogramprepedunclebakeoutabnegativeoctachlorideundejectedopsyprionacelacinulasmudfatsammyblackbushrifledomautoserotherapypandeanredecisionconfricamentumsomaticovisceral",
                                                  "extumescenceintwinementarenginternuncewoohoodiscodactylouseccoproticophorichindustanduskeroverpublicizingumbrettranshumanizehornslatebelozengednonannexationhousefurnishingsdinnerlysylvestralrefordsupercrimescrotectomyimperatesgriddlerspostallantoicnonsuspensiveresalutationmainpinbradyseisms",
                                                  "nonactualnessegiptononcategoricalnesslecturessdeanthropomorphicsoverperchfibrinokinasebeentosophisticativegleicheniaceaeophiodontidaegroomishbescribblingsprecommunicationcataphrenicprecogitatingparochialitiesinfranchisethebsesquisquarezamindarieshospitaangelshipunderpriestprimegiltsanctcrotonbughuddroun",
                                                  "pseudolunulanonlyricalnessscatchiebeerhallspostclaviculariguassuunloathlyunallusivelyovercontributionsirventunprofoundsemianunmammaliannonderogativecryptovolcanismantisudoralpleasablenesssquilliannucleohistonenondisparaginguncallusedcageylysephyrulasaumurelencticalcivilizadeintramorainicfrontstall",
                                                  "epithalamitemplelikebiforinsalmanazarsblepharoncosissprediscountablecummockacheuleanunbanneredfleyednessdecohesionshirtlessnessamexpentadecahydratedunearthliestadetautophotoelectrictarantulatedtenderishtinynessantiasthmaticsunretrogradingporokeratosistaprootedskeraunophobiatarrietrollflowers",
                                                  "jettinglydessignmentsnontravelerpalatiumglucocorticorduninthronedtertiiagaricalesswaptreunenonruminationthyreoiditispimanunderhangespadongheleemsbicyclismmethylidynehomoclinalrosalgercorrealgobacknontrademadreporaldioptographunderbrewmennoniteunconceitedlys",
                                                  "intersolublesubtowergorgoniaprejudiciousnesslerizationbahanprelexicalcopertarentrayeusepseudobranchathoniteyakshadutchingcajanusginkgoalesabudefduflaparohysterectomyantidiphtheriainquietnessnonpuebloprereceiverglossemicintergonialnonplatitudinouslyphosphoreousdisauncountermandedabbycircuminsularbinotic",
                                                  "alumnalscalyclinonmetamorphosishemisaprophyticrewarehousenonsupporterurbanakylcrysticpreburnunsuperlativeinsectiferoussoldatfirstersalagounprobatedcytoblastemousdowagerismlymphorrheasubarticlestntsidioglossiaspottledbackspeiringlovesomenessspongiosityantigonorrhealextracalicular",
                                                  "corrigesalintataophyllogenoussprisaltrivantrenettespecificativelypaedotrophiesmillibarnmelolonthineplenartiesctenodontumbelliferoneregraduateunorganicallypelagraembootaunadmirablyfingerfishesrearraysinistruousresolicitationforeweighscomodatograviersseptenniadtwitchfireethicosocial",
                                                  "forepolingsemifeudalismunhumannesschaungedadvolutionwinterboundunneedfulnessserenditecanangapetrolintocodynamometerdisquietednesslachrymaeformpostzygapophysisverminlikehydagedolosunannihilatorymurlackschamberwomansuperunityscnidoscoluswiwimoorillsuncalkgattinehargeisanemoricole"
                                              };

    }
}