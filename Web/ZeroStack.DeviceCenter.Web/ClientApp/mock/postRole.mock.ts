// @ts-ignore
import { Request, Response } from 'express';

export default {
  'POST /api/Roles': (req: Request, res: Response) => {
    res
      .status(200)
      .send({
        id: 61,
        name: '于秀英',
        tenantRoleName: '走林龙连约与提所会北温导议年东。',
        displayName: '各带和民百处治又际引六被我。',
        creationTime: '1990-12-20 10:33:34',
      });
  },
};
