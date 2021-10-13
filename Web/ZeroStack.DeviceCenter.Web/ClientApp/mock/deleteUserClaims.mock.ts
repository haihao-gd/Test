// @ts-ignore
import { Request, Response } from 'express';

export default {
  'DELETE /api/UserClaims/{userId}': (req: Request, res: Response) => {
    res.status(200).send({});
  },
};
