﻿// <auto-generated />

using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Infrastructure;

namespace Pgpg.EntityFramework.Migrations
{
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class Added_ExcludedUsers_To_NotificationInfo : IMigrationMetadata
    {
        string IMigrationMetadata.Id
        {
            get { return "201602091537256_Added_ExcludedUsers_To_NotificationInfo"; }
        }

        string IMigrationMetadata.Source
        {
            get { return null; }
        }

        string IMigrationMetadata.Target
        {
            get { return "H4sIAAAAAAAEAO0923LcupHvW7X/MDVPScqZkeRjH8clJSVL9olyLEuxlOzWvqgoEhox5pATkiNrdmu/bB/2k/YXFuAV9wsJkkOZpRcNLo1Gd6PRaDSa//c//3v8p+d1MHsCceJH4cn8cHEwn4HQjTw/XJ3Mt+nD79/N//THf/2X44/e+nn297Lda9QO9gyTk/ljmm7eL5eJ+wjWTrJY+24cJdFDunCj9dLxouXRwcEfloeHSwBBzCGs2ez46zZM/TXIfsCfZ1Hogk26dYLLyANBUpTDmpsM6uyLswbJxnHByfxydxatN064Q2WL0/vNf4A4ugXrTeCkYPERwk13n2JY9z2Kv81np4HvQCRvQPAwnzlhGKVOCqfw/m8JuEnjKFzdbGCBE9zuNgC2e3CCBBRTe183153lwRGa5bLuWIJyt0karQ0BHr4uyLakuzci/rwiKyRsTig064y4J/PTreenn6PVfEYP9v4siFFD2OZ+s8jaQelYlB1ezVAx4sKrSkAOFj/Dv8NXs7NtkG5jcBKCbRo7wavZ9fY+8N1fwe42+gbCk3AbBDheEDNYRxTAous42oA43X0FDwW2F958tiT7LemOVTesTz6PizB9+9N89gUO7twHoGI7NuebNIrBLyAEMRQr79pJUxCHCAbICMeMTo11C0InTIkRXx+pOkGZjBkk5V1uQPzkuwD9KPtBsYbsmc8unefPIFyljyfzozdv57NP/jPwypJiwn8LfbjWYac03gLVWJcgfYy8Xoa6dtAKhiRPJEMdHhz9ZGGsj8/A3SKe3/r1zM4h1/PfjJBoQjvfxsVSJSTAENxZ4EOBu9icel4MEhk13tqgRT6cgsWHR+8sDPUhjr4jeQ8fos7F6eMz2l4wZvBGOjg4sDDUxRr+SqLQgfqjwXrGuzfSIWeZ8obi69ie6/Gy3jOkO8kHx/22iqNt6P0lus/5K99SiA7Jgumf7TDk5vLuR95cIFnQUBIGvzk80uKvoTaCA5/GK7lO/undm5/11qzh4LcxtPyg3YjR+fCtMZQv4DmFkKzo+s9OIoalWOfJ6b0TelEIKrn5EEUBcEJjLK5jP4ozqSm4Ak1dcg3VLUx3nxg41nbGDJiGUtTXM37oxLur+38AN5WpGPmJAa1FZwUWOLRXM3mfM7h8a310iEzd/dVHv2x9z5hZH3YpqNZ5ThpincN/+WtcOo42az+iM0YUfoISAwl6A9I0UzSKk8lmA6mdVSyKnsmCC6n9kWX2wUkAtt4oTOXWSI4Ss7GrWPTFefJX2fT4AOezryDI6pNHf1Mgxp3/XdXjUxytv0aBiORlw7ubaBu7SAdEOq1vnXgF0na8N+F20aXi9jiPpFwZsGc1KKz6151YDOd+AlXmTjG25tnFcOyL5BwE8BDZeofNwTQx57Oewg1UbV1cRp7/UEh5OxiN0N/v/d/C7mB9Wzi9T2CtmxYi+wIPH5acA4bC83cn2ErdTron2hdlAeceArN1cAnl2M86ursFD8CwxpHA6WHHrMR0wGcnXG2h3a8i1+fIdQL/P3O9wek/mRr6TGynWDpZ34PaJ67UIWnHzToZQS/bCOKopFvwLPWH6Kg1BGOcqm0fL/ZKqg6i4qqje88mG+SahYsdy3bi258PD96960afT7pKoau+RGlFHJ17Ibx9sqB7j+tWqJEXFp/yMOcuxUWiyXWPeiA0jGKauhdbivvgSjJ7iWaohztNErC+D3Z/3cLdF65xVTSFzenWstiZsXkDngBzFYULcd3AUA5zJSS9eXx9ePCzFWo9u8HWA16PQ5ZGRS+DjWePuNneJ27sb9rvFzSkH2DvsBeBNvymNWnzIbT5fiuKq3jlhMUJFk5LeeLF2ycLuvd01rWlQq6dGFCdNM4tUCgHMG61nH8dDT455kZ52JXFYZw9+oEHpZ8biEFrnLu6dR2EIWzEBGCIW/KCL2RY5wu2C5xLTNQ4l7NrtBNcg3jtJ0l2vNC7Ct6mj1Fcej+Z7tM18N5eA18kv8RwS2qvNPfbtkHLpaVUIxDJggvI/gUvi6uUXgirjm54EQ9aUg6BSBZcQINTzvx8ZiRzzaNoRcL3oiJpu784HzZc7gZNwm2rWpFh++BABrYF1EUUQTdRjpMt//Js+RoG1zRGyu2OaFRbxHQdY7wzDUxtdkxOxNgRjSjssDo+dngDU+xoWRCjyLak8KQb8JFlWhmfgaptOBEjSzSi8MTq+CjiDUyxyxWhGLGynsIpL+ajU9S1CtTPGWbHYqiNrpdmMXR8DoM/H3xo5Psumj59Z6C4rnuMtoF39uiEK3DtJMn3KPauQvRC7nO08sO2mxni5mc//Ga4FSDBQHMvbm5U0StW3j0PYjXcbONwiHFLVvd/fP+4dvxA/ZS9o9igiyQb/ywKH/x43d5Yw6FlsmrJi63Hva8gAalixNdWRkS7a6YQGj50dVP/CdhQJoOs0kankOlA8MMdCDK7U3AgoOsYm4xpYPtAkAEVHAjoOj52nR8IMsiyAwG3AR/Z1geCTN/xzwL5AEU9jV1WLMApr7N9NMlgC44mdB0fsTZHk8zTJ8arqKYwykr5uORVplgUvlMJInULCpeygo9OVWvxyJbLI3Nkw4r5uNg6shW2fTOXeNZ5CpbgjGUjdCqjLix78j2k+vo2z8uRe4jcN5JY1dWETGDzS4hJXjuRV/OLvD0x9LTFT/MGMTsFroqMbwtrt4UvUOz6SoxoKRR0qGfq0/nMwsP45s5pziP5l+aX7uMJuDvMTbYowdJ+RjTZ8Y9NHqdRarQ2HqfiQCjwObG1zLGS08S236kYQuB5YmtFOLbxPsnSoxXgOfnQyBoRXrKMZ609YsUYMp+YoIkI3dZ+MamnpfRecHwtVJUIP6m/xejM2O6tMQ/CD/BmzPbzr5booHi0eksufWfEu768RX9HTiMZNH2iJPJhTI+Vej1YGkoTzZ228PbsZLVdY1ItSCt8kXwKnFX9+Yzm6b5LmK2ULTTJPRAHO7iTFLbwLqUfYVyC9T2IK7/r9/ksO7ufzN8wJCWafgBB9P1LFK+doOqC8rbI+tDNFUOc3kdPgOpzpBjiz/7qsW78hmVuzkYJa/nP9M04K3mAXUDsl6/5xl9QRUHBm63rZmEpJZfkzf/NicOa4PK2H+M4iqvGr+WNPzkpxnfOMlVyUrBJtmElF6RdXub6WkKYv4VQl3m67PyKtz3UoeJpkkSun02PPDgIcieTg38MvZlRIuXaqBEku858UCgxF1w2J/PfMdPVHbF6hceMSI9xOKfNgKswP3jNkJMCfbXozElcx2O3HUhRjyyBlgNADwt9B8VIoedwfpiyZoYfuv7GCUxmQgHRtFYQktVwdM052IAQGRomPNTBA3NFsehUo1K0VJHueInJqlyExS84RcKk8QS1FiTWwiUl6mCxYPWozlgcoVWNxa6QRiKonH8P4qekiw4O9UP8QSSPiYcSCYE4OIo895loRGE8lQImV14biZEIgx6kR0RQnaGp88JwkoN7DKVc5joPW0oOz9vYr+RwMOhLcjgE1RmaujcYTnIYd6mU1WLPaUsZErpa+xUkERp9SZOIvjrj8y50BpSrPORTznQq/lPOaqv2Nh8TgdAVMYCdGFAcQvQmbMSkdUYdXqzw0F0pR7lxvMMJGC9qmEKHTW7QocRxyNOX2HFIMQ7Zy8OzpWymYrWHkzcyMpxCJI8Q7U64CCr0JVbEjMchUNXVr5SV7C1wA5NIBJMjIT1oH3pKfckIPe29FxNO0IqIr7IIlpq5ZaifvnkuCXvpzTYX49CD5IgJOxYXASesSMFthZugsRQN6ioQ49CfFI3YXUAFfyk4LbnBaSw95nc01oWn/8sVPj11Bh76NkUUkKfgso6PqbEIDe9nUiDSn0S9CF8THUSpYL/MlubLlMKaFkVi9mZPCybWnxg1sanr6LPhDl8Fu6XHJPqBcUsnN/UmuZnsNT91kcP3deYiaTgC6WBy1Yl4Kk5cVzNWz9Uigdn7/iTCoAd5ERF0LOcsOhWgXHIUZ6xGkjPo+UqEQV+SM+KzVYa/tqHMbW1NhoY3kaVo9CVNL8I8zmaic2dGN9SVpo7uMBh0ODKI2vR1ZyYiT1/C2PDOrMw4MZzsKaxsrI01/TWclc0Zvi8B2XMrO38uA/uksAf2dINICnB+jxrwP8cMtWgRcJ9wvxKSDwCVQAl66/koDWMyn9VPdQoxKOs4gkQCIZ/ecCARDfLnEyqQfujEu6v7fwA35ULE6pXACgcfD07lD1WAIGO2eZDoQHsFwPLjzVzCs1/O1oaHPrGtCTP/orcCLvFigwOXfRFrABD/gKIKOPvZRsVAdLgzbwA2+lsBlEiJx4DjbLMKeHmsBAsp1+iKztlbTk7n3OrU6FzmG+RCKKK5NMCIJlHHUCiASJaVLiFzNc2DUO5mGhNRCTvdRksOUScdWeS1Y4Bj+waj3wQvimZYH9nbIP6NFWE36D1CqgjAUZvMHmr63ggDXqt12mImqaRBQcknyVjqab5+ISanfv+CTYwjLRK6qZ+7mIBuQDz6ZQCPZkwb8XxEDw3waRSaT0IV0UsJJZSmBCCSkQgIIPR5sajzvF7mBOD5uboiAJtQREAFuf+GnYTQg2NOD6HPpjOiFDusiBSc6G8O1mT8d4Npk2HbFIASRzszJiwkwbSFnhYWdZ6vxZwAPBcJBoXA2Q4ZCptIQABOiCyLNBkkaz5pMraV6l/gZ2ey9f4umC//3plFmbl3Np81c8WMgRDZIQ3mzUuTxU5eFZdIoC+JTMTmUBm6EkJIYhE7UHS8bFxCUuhtgZLwumak6GkjpBN/CcmgtrUF8WHNpt+PFS3MLCYkg4EpoIp6akaYPg0CJpGZkCwa6lIUqNOMDD0pTTygRLRV8DzhrJanfOHm2wTl/VaTrcF0mQgJzpzlURSs116xO3C3dTmUDiWeuegXEUBvVxCGA5gToKf9gH9fLaKCgTaUX22b06NPPchctorooXdMEF7JmlOh12MCfu8nooBSGfIuBs3nbVMZljnfqkusqu54eeM+grVTFBwvYRMXbNKtE0DRA0FSVlw6mw3aceqeRcnsZuO4EOmz39/MZ8/rIExO5o9punm/XCYZ6GSx9t04SqKHdOFG66XjRcujg4M/LA8Pl+scxtIlhIm+cqtGgurRWQGqFg4NMf3kx0l67qTOvYNSXp15a6aZ8MpO4Csuh6Vv5VjGlV7jsgf6P+8lzySe9/wUw7rvUfytvt1jL0EL0LDtao3uT7MciphQiLvCzjeuEzgxJ2XjWRRs16H4Klfcu76CxWGIL2bFkMogExyOKPBEDOUGxE++m1GdBEVU6MO7BOlj5LHg8HJ9aNcO4nGa6WocGl6uD+3jM3C3aJXniSJxgFRVA5jnxbctBHDran3YZ4EPRfZiU30PEofMVJrCZXmEl+tD+xBH35HYZfdHODiiwoSiSJFyKFkV68O6WMNfSRTiYaLE2uXUN4POX9f8FgacymIikHqmOIWVs9COl5TWY4I9GNVL7Yi0LtfS9FToRHfqng3BMNf7GjC62QDgcGjeJIiq0AjOabxKGDh5ocGGFEPab5HdRmxIVak+JPRZZNiPVa5EhT48ZMdz4REVBss1Ob13Qi8KAc1AvMJgc6qy+xJbU1VqsMyJhMbEQidqDCHydZ4ian449UGESXWoPfBwqwaKQ9q9G52BsvhSK70o2hvu0dER3fGPnwzWnJEqAN2wEnugS1g34ne7GSx45MpblAl7BSlxcZjnPgoyW/uZ9dGFqCjYepGg/68efmPGX3JKvx0NZ1l72tSSLr6NhoMoin7UrcSq4sgN8JHqjUZ+A0ZrcEnQr9JouL9UV3udbywNRELYc181DeQypMGOBURUmJjW1bfVSMO6KjbAjXybR2Anf7angMnVimSN2eGE/RwbfUphWzQZgU8MnQdnYugva59oqFTqhwsd+qY5DyAauKl1oOzRzjMWveXSbsa8ZNJ8YoiT5ntBmi9/YtWr9rtlrg6zMRtoQD6kfdeCJfasEiNrDO7wisty4vquKNOH8iugPJlZQb+n10m3vADdQr486063MK/XzJWKGkRHJzhsXI5VxNQa7PfMXaHollAGoWQJC6muMfB5VixnYdJ1TaCeJglY3we7v26dAC1cTviBsrHpuIwDtyo1ib0oPyJIBl6UpaaxINQVQVVodPcebD3gceExlea7Z8LfPs2iFyYdK3t53o++ZV6wt9O9anD7btXZicbqbl+YdPCkTYTahH1J3Z0WYdICmGsONYh91xb1lwepqEZgHCEWebTcRmziLRmE6S5g8ohNOpB4ENFDlAOTXqdJoAObo2c0N5AXyS8xVJuslqiKf1T5tbrb8hMmjkjSynSGOARRisMMChPzIMgZuU+RUmY8RaI3ap4an5UYnvJJMIpAFlG6DJsrvoEw8Lt1w3/7FucNShnp0ltJWWpmuz442yBlbdeieJz35pNNPtnkI7TJ81fa3e6kDXQlv1s3uhL+fPChAeO7KGST8RgwtQa3D4/RNvDOHp1wBa6dJIEU8a5C9FanyJZJXEqoGpvt/p/98BvPAijL9aGdbtNHyKPSj8y5Cee36FP73mzjkAFSFZp4jXLC016jstTAf7p2/ID7rJSsMdlhsp7QUnvw4zW70dC1hrgWPTMWsi4vQRNzyn4FCUhZ+Jxqs30iWyT8LQirMnrK5qb+E6CpXJaarUZWwuvSIeydyVqZrJWRWivCJJg2TZZ8y21mtwj67slBny+6CGVY9uR7KOEQIbVklZFZlfVhgt6Iir0Sra4dB+UYDQWrTweCHbkydi1Oqk8knz08+23u5xzDS70uY0pan1+myN5pmWNC3OUq5yeJ01jkoo4drnGX48EmKgzOuM2yAnTmLbZ1upxOcpOeG6Gey9wfPb1ioMdqGE2rB2afzXECewoaXWfge00h0SnPa17Ux5oYUH77jOnkjddQhscf22lnNdB0oCHy6ictz1klTA5fukk1elFS/a5y+Bb5c4nEvhkdUJrebP5JkcuXTqibN5nPSq8SVD67JAXrBWqwuPlnkKfcrBtcQqY+gCS9jb6B8GR+dHB4NJ+dBr6T5KmUi1TB7+mPZWrlDj58jXIHA2+9pLubZyBGUJLECzj5hxGbqtu58rObzNc9z3ehA8F/8gNoud2VDe8und2fnSeQL7wypL/WNESvhPx5Dh78kJOI5fhXsKMlqpRe2RdZj5d0x2OOysm/enfvr3zEx0yl/QKgmEE96V07KcQrRA1BNpH57Ms2CJx7lK36wQkSZonRI9QKKB8nG6SGkX0VVQGiXHckomYwiGTAOaDwyYndRwd9Etx5/gzCVfoI5fXNW1PQeGJgu5DxJMESyIcHRz+ZgqbSBefQPcjyNPttyGROkmAut7WAMXmBJVN/azxxPEWwjKZH70whE9mC7QoCljpYBvjg4MAUMi9/cJt1xs8X3Hjp42mCW80c34GlCl+RVnfMqrjK0Suh5Bu0XZvDzXP2knB/s3aef2u+X1R5e3NoydoJgiZqhMjZS+s3ZjO/CD3wfDL/r6zz+9nFv99hOXXvMFivZlcxNHPez45m/22ME5H3V6xztRYanvK3lBveR8jNZ3bYYGZ10uAcl9QPd42UP2G9t9yWKLtdX6/pawthLt0+FMU29P+5BX6mD5CzzJhARQ7eHBpctvfZdHQWrjaFZMkmx6xMTS0ILaDFpZTBTjeiRcUxa+rbAcxC0NBgVcdKZx2QOktndAvmCfVEo5U0aK+o6nuGihNp/bHChzS/XxjPaXSYJfva3PYhHnxoH1S0QGN3TNj+boofebHUZrWSF0rtrBf+FZItmHbmux9aU1st8BJsKp1WbB9L/qsmI0+Kyt7OpDZPzM2ILnWdq/BtNPDHTPpz0p/t9GeWnrOBJkP9pnsA6zqNzC5qV7eVr6osH+iyIGx9X3DzQ2IzZ9ukRqyrEXkIyyi8QmyWNsurgufPZwRYa0sl8nnqu7W1nBNUTjnLNzqqVHJdTKaWEVs2Vp3qs53bt8rIaUEomCyfFmBieT4tQBuxSmPyXKrMI1nnsdpIrTVsZ0ERGr5TWrvfkYrurlQVd/kIlYf1pwa3QuqdpEOEs2usdupNtQd0iP0Rhf2Y95gOyfS6PZNHpo2Z+FKVBqY79OThY4Ydo3tvj0/Dda5V4y2g7Nrm9ixPImH7YKDpYWwCe3IHTud4AzV7Lc8tOGbl09HyqvKeNl9e+yEjLKjyUb1ZlELeq42SbWzkU1ZSg6EHCW3IUjCoDAvUqCcbJhtqjHZLJ3qj01iHMtVlc+WB5bhsDoRrmGksuLJfmyWnJGyD+JTurR4N4hD9Wyml0dtMGtRigbSy03vbUjWmRvTXn5X2/pHltVQpddSop/0jG2qM+0dXpuc1k+5T7VHVuodQZfdsrvzwrJ5tbEh+Fk/tbXSoDaTK8mkXbJ3z0/I5hEz/afnqnc0C2lyuBCk/7d7PcfJ+SvloPACVALTd9lknaGm3XLtYB0MahpMRJxO/yYh7eUYcJ8nnmM2ejvw4ejFeZIZRy9vtNZ5ttNVuayQfbK7OSTyaiQfHtTlKp622+Lw4d/6QlsmADmqlkWcttrZ1koXpes76Ki6yZaocMHmzUbpgutMVbicu/GEf83Z0p9n+PDqd3dQabDq7vaSz2wt4AdHSrLnLEnTe4ZxvlVyFTh5qaZZFGlEzba2eYZPEOPJFYgWt10q0jKTcOAyT12msAfB7HBapsjm18ODlJm0FcL+t69MkiVw/Q5A05sjkPaWlRsnbx9CbIS8ClpkkRwml+1xUZZfbIPXRU1mIwMn8YLE4ZPL5XoW5oTJDZhdKCXrmJK7DfqwMzcMTIUElHMJxoatIlH7HDAOXC0CRsr6DLmqSNHZ8NrXrdeyHrr9xAooIVDvNVYgmV0Gka87BBoRobfGnqjOiJCH/8bKCT1FbRYfjJSZBcsFiNODZox94ELhQqFhFi3GUreSIGc1WMew8Qa0BfEsyo5F62rrwcOeuM24deD6IBGUxFZgKFApOHgyCMTMvMBIQ1IURCh4cS4Ig+J6rdeZX89IZS5H+uj+uY8fYietdc13xSZL+uE4fxyfWd816nQ+w9Mh/zhcpTbneka1ZX1XTCBSlo5cZ0Zc62cGGF5T6yU5LaenucMK+KsJx4dSOWoAUb6j2VpA4HyrdI4WTP5Khxs8LRy0t/LiOvRUS/hdDLZsjPC3xMnTDaDRCcYXc14mzvNjGoJRFo+a38LuY+3neLLje14lz4vpenDcLrtv2c+8P33t0ThuwfmindMH2Xh0N04rfHzdDGSWmsui0ebZ3Vp0BV3q068Qfp+zPjOdRpgOWa6mM0TFbW6kMzOksj0NfFjxzPn8BZ3Ptc/k+2O4Zt/uy3H9obu+DzZ5xu1fT7Ydm+d4YbRnfdVz+Wux66S5/bf4O4vIvH6ENJ0g9mYF9qo7+zEBt4erVDMxjHauvppcGCv2Fc4bnxYfYi/b1B8Dr2MmCd3VV/pX0k7l3jz79m4dfnt5vygYJRyLIUdivzrLDcdoIxiVaagyOf8SSMy5RzR1ys8EbqUekAzGZMekGgokWzdQDVt45ZqSqRjBEUa8egvv9LVZmeK0EQ5cNGo2df7tGZ/y8pQIH1EiNB/P0g0WAbSIYGW9oNjKbo16KBdtcAyO8kxo7NoyUwYhtIsCCbqgenWNjMMNz2gjGx00u1cj57sYMlhcL4OeX7yrIudnOQM6LBZBRpR7kInqHC76ok4xRBCzpDCQgUF0lGUaPUGKWqxhduUNVQ5SWEDNCWSEYIK/WI5SGZuE3kxDQTMPwH/1wsdBey7zGLCaYfcPsaIIXGjOsD7nR6TzpIExWauuEHbEyxowTv8PAutNV9GmKnLAGMcSvCjiE0HyCQExGxPhsOmylhCz8JwcG0BqQhwmZ51BFHlbP8aFgKOcFkknXUbWKXk0nh3v7RJMTegT3fXKMc0s0Q7kXbO+nWWyboslxwoAtTInY6qtuRamdiREWk2B2QkdWyykKbb+sO6fWzpQL20QwWU58pQVO4rZU1SsvtDOp2iASzIt/gdxyajy+2eMWJ7qNMztVDFzLKZIGZNanLLI1QcUGoQr32v8JSiw/WVSTFVOvh+np7IFaYTz7z0mZmpFGqjRDtEdlgwdciHQo32vdemJanG4wJSaygDMvefRBS4Fkdj1LOx5ziS6aWFc6s9OJ6agTjYvlfZ6iwuqUX5+aozmw1Ylf4olm25FqacvFMitHdVNV1R0vc79RUQB/Qg3irAAUSBAkWenx8us2RFlE8l/nIPFXNYhjCDMELnEzVrVB/rHyio7CqGxCJR65BKnjOalzGqf+g+OmsNoFkJGIg1nmRJTV/B54F+HVNt1s0/Kzkzgx0EWfbPzjJYPz8VXuZrcxBYimjxKvXIUftn7gVXh/4qQDEoBAN4hFzhvEyxTlvlntKkhfolATUEG+6uLzFqw3AQSWXIU3Dso6Z44bVDmfwcpxd3XCXxEQNSNIsh+f+84qdtZJAaPuD39CGfbWz3/8f9M6iZFupAEA"; }
        }
    }
}