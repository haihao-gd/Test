// @ts-ignore
import { Request, Response } from 'express';

export default {
  'POST /api/Tenants': (req: Request, res: Response) => {
    res
      .status(200)
      .send({
        name: '徐娜',
        displayName: '争派式新平形结百计始历五江统是压。',
        adminUserName: '速展真北张国先委内我确干学作育气。',
        adminPassword: '却面它低议设验七毛离化然世。',
        connectionString: '组接这拉算越列之族立战说北。',
      });
  },
};
