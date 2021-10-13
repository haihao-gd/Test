// @ts-ignore
import { Request, Response } from 'express';

export default {
  'POST /api/TenantClaims': (req: Request, res: Response) => {
    res
      .status(200)
      .send({
        id: 68,
        tenantId: 'E8E2Bb4D-f2aB-8B99-1A73-546EFCD7D99E',
        claimType: 15,
        claimValue: '需也色了经劳书切强必才然毛来。',
      });
  },
};
