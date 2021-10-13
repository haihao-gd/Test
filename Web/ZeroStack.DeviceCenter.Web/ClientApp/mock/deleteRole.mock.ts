// @ts-ignore
import { Request, Response } from 'express';

export default {
  'DELETE /api/Roles/{id}': (req: Request, res: Response) => {
    res.status(200).send({});
  },
};
