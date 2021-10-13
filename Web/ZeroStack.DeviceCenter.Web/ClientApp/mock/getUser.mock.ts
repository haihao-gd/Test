// @ts-ignore
import { Request, Response } from 'express';

export default {
  'GET /api/Users/{id}': (req: Request, res: Response) => {
    res
      .status(200)
      .send({
        id: 60,
        userName: '都力提空生个线始身如把空想因四收。',
        tenantUserName: '三说战质上上最即无因商此南史明节。',
        phoneNumber: '取你加中数效林动习则办在农拉世老。',
        lockoutEnabled: false,
        lockoutEnd: '1991-03-30 13:29:10',
        displayName: '年成党口员形说被先南儿科合义样所。',
        creationTime: '1977-03-25 10:53:47',
      });
  },
};
