// @ts-ignore
import { Request, Response } from 'express';

export default {
  'GET /api/Roles/{id}': (req: Request, res: Response) => {
    res
      .status(200)
      .send({
        id: 60,
        name: '程杰',
        tenantRoleName: '际们造压压受深合军连回定到。',
        displayName: '认老理林圆接广果按已阶知。',
        creationTime: '2017-12-26 12:54:18',
      });
  },
};
