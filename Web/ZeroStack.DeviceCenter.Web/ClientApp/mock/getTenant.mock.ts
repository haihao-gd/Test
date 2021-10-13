// @ts-ignore
import { Request, Response } from 'express';

export default {
  'GET /api/Tenants/{id}': (req: Request, res: Response) => {
    res
      .status(200)
      .send({
        id: '3DA3ee47-CC4C-1fA2-Cc7F-AFbC12C3E8e0',
        name: '韩娟',
        displayName: '程权直将农规些先流会界立支。',
        connectionString: '南你何二要矿行作族层头林好至。',
        creationTime: '2015-07-26 13:20:53',
      });
  },
};
