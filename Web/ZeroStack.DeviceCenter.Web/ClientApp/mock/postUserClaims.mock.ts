// @ts-ignore
import { Request, Response } from 'express';

export default {
  'POST /api/UserClaims/{userId}': (req: Request, res: Response) => {
    res.status(200).send([
      { claimType: 28, claimValue: '金马西向每步形率火集或王听五存不。' },
      { claimType: 29, claimValue: '南强动其声当与知维们本动素再省。' },
      { claimType: 30, claimValue: '光具下列直列始办电情动石严指。' },
      { claimType: 31, claimValue: '示采就划国青形二斗可族布格象样便明酸。' },
      { claimType: 32, claimValue: '装复车清把七全做前国住全道党众放日。' },
      { claimType: 33, claimValue: '很照年强毛写往消解头那时第。' },
      { claimType: 34, claimValue: '空道前好而定复米完况利平认信报。' },
      { claimType: 35, claimValue: '统声务术正广花场料金产明什教以从之。' },
      { claimType: 36, claimValue: '社是维三战展当再取圆王出农很集天出。' },
      { claimType: 37, claimValue: '克约反会圆都行机府利值素月更重类半。' },
      { claimType: 38, claimValue: '米入达情总明是声名术成治。' },
      { claimType: 39, claimValue: '半走省热再连民劳那里规阶历有计如。' },
      { claimType: 40, claimValue: '适就县什传风民平回义非表计业。' },
      { claimType: 41, claimValue: '开建务人厂率委北这农利七。' },
    ]);
  },
};
