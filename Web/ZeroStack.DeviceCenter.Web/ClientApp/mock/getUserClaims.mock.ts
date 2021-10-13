// @ts-ignore
import { Request, Response } from 'express';

export default {
  'GET /api/UserClaims/{userId}': (req: Request, res: Response) => {
    res.status(200).send([
      { claimType: 17, claimValue: '消常资总红周究月白拉调区。' },
      { claimType: 18, claimValue: '图风由拉育车收性就马原指际天。' },
      { claimType: 19, claimValue: '按能一命出开实商期列二位为院你。' },
      { claimType: 20, claimValue: '较热说着应但千组七学克于和具水。' },
      { claimType: 21, claimValue: '收间组儿员价受十高计油单员非局阶。' },
      { claimType: 22, claimValue: '别分非即业只位养事直极中志之写次。' },
      { claimType: 23, claimValue: '去见识发局对记化系基但在会号证被。' },
      { claimType: 24, claimValue: '省米采看始确术理教大式也大接化什。' },
      { claimType: 25, claimValue: '派使圆或术眼想员龙价争养气。' },
      { claimType: 26, claimValue: '题道装六里江小分算众王增给消十。' },
      { claimType: 27, claimValue: '现细你军党住党安要放情则外打名列。' },
    ]);
  },
};
