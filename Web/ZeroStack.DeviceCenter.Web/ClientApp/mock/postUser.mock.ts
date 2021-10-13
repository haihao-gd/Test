// @ts-ignore
import { Request, Response } from 'express';

export default {
  'POST /api/Users': (req: Request, res: Response) => {
    res
      .status(200)
      .send({
        id: 61,
        userName: '可四由数内马严化传名至路龙。',
        tenantUserName: '少计又况些广几强展资值更月革意何精取。',
        phoneNumber: '们能基运各重龙接至最济动还从象。',
        lockoutEnabled: true,
        lockoutEnd: '2016-10-22 16:23:33',
        displayName: '南存此历便价容县养强运老王九就性三角。',
        creationTime: '1971-03-08 13:52:56',
      });
  },
};
