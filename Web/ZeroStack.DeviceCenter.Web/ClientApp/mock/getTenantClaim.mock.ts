// @ts-ignore
import { Request, Response } from 'express';

export default {
  'GET /api/TenantClaims/{id}': (req: Request, res: Response) => {
    res
      .status(200)
      .send({
        id: 100,
        tenantId: 'e3cF14F2-EA5c-E93f-84e5-381964FAd7eb',
        claimType: 16,
        claimValue: '收约把加广局命支科部花系。',
      });
  },
};
