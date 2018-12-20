import argparse
import sys

keywords_list = ['ADD', 'ALL', 'ALTER', 'AND', 'ANY', 'AS', 'ASC', 'AUTHORIZATION', 'BACKUP', 'BEGIN', 'BETWEEN',
                 'BREAK', 'BROWSE', 'BULK', 'BY', 'CASCADE', 'CASE', 'CHECK', 'CHECKPOINT', 'CLOSE', 'CLUSTERED',
                 'COALESCE', 'COLLATE', 'COLUMN', 'COMMIT', 'COMPUTE', 'CONSTRAINT', 'CONTAINS', 'CONTAINSTABLE',
                 'CONTINUE', 'CONVERT', 'CREATE', 'CROSS', 'CURRENT', 'CURRENT_DATE', 'CURRENT_TIME', 'CURRENT_TIMESTAMP',
                 'CURRENT_USER', 'CURSOR', 'DATABASE', 'DBCC', 'DEALLOCATE', 'DECLARE', 'DEFAULT', 'DELETE', 'DENY', 'DESC',
                 'DISK', 'DISTINCT', 'DISTRIBUTED', 'DOUBLE', 'DROP', 'DUMP', 'ELSE', 'END', 'ERRLVL', 'ESCAPE', 'EXCEPT', 'EXEC',
                 'EXECUTE', 'EXISTS', 'EXIT', 'EXTERNAL', 'FETCH', 'FILE', 'FILLFACTOR', 'FOR', 'FOREIGN', 'FREETEXT', 'FREETEXTTABLE',
                 'FROM', 'FULL', 'FUNCTION', 'GOTO', 'GRANT', 'GROUP', 'HAVING', 'HOLDLOCK', 'IDENTITY', 'IDENTITYCOL', 'IDENTITY_INSERT',
                 'IF', 'IN', 'INDEX', 'INNER', 'INSERT', 'INTERSECT', 'INTO', 'IS', 'JOIN', 'KEY', 'KILL', 'LEFT', 'LIKE', 'LINENO', 'LOAD',
                 'MERGE', 'NATIONAL', 'NOCHECK', 'NONCLUSTERED', 'NOT', 'NULL', 'NULLIF', 'OF', 'OFF', 'OFFSETS', 'ON', 'OPEN', 'OPENDATASOURCE',
                 'OPENQUERY', 'OPENROWSET', 'OPENXML', 'OPTION', 'OR', 'ORDER', 'OUTER', 'OVER', 'PERCENT', 'PIVOT', 'PLAN', 'PRECISION',
                 'PRIMARY', 'PRINT', 'PROC', 'PROCEDURE', 'PUBLIC', 'RAISERROR', 'READ', 'READTEXT', 'RECONFIGURE', 'REFERENCES', 'REPLICATION',
                 'RESTORE', 'RESTRICT', 'RETURN', 'REVERT', 'REVOKE', 'RIGHT', 'ROLLBACK', 'ROWCOUNT', 'ROWGUIDCOL', 'RULE', 'SAVE', 'SCHEMA',
                 'SECURITYAUDIT', 'SELECT', 'SEMANTICKEYPHRASETABLE', 'SEMANTICSIMILARITYDETAILSTABLE', 'SEMANTICSIMILARITYTABLE', 'SESSION_USER',
                 'SET', 'SETUSER', 'SHUTDOWN', 'SOME', 'STATISTICS', 'SYSTEM_USER', 'TABLE', 'TABLESAMPLE', 'TEXTSIZE', 'THEN', 'TO', 'TOP',
                 'TRAN', 'TRANSACTION', 'TRIGGER', 'TRUNCATE', 'TRY_CONVERT', 'TSEQUAL', 'UNION', 'UNIQUE', 'UNPIVOT', 'UPDATE', 'UPDATETEXT',
                 'USE', 'USER', 'VALUES', 'VARYING', 'VIEW', 'WAITFOR', 'WHEN', 'WHERE', 'WHILE', 'WITH', 'WITHIN GROUP', 'WRITETEXT',
                 "'", '+', '*', '|', '"', '{', '}']
keywords = {'EXECUTE': 0, 'TRANSACTION': 0, 'OPENROWSET': 0, 'THEN': 0, 'OVER': 0, 'BETWEEN': 0, 'LOAD': 0, 'CURRENT_DATE': 0, 'KILL': 0,
            'FILE': 0, 'WITH': 0, 'BY': 0, 'NONCLUSTERED': 0, 'FREETEXTTABLE': 0, 'TABLE': 0, 'SYSTEM_USER': 0, 'REPLICATION': 0, 'EXCEPT': 0,
            'SESSION_USER': 0, 'READ': 0, 'READTEXT': 0, 'CHECK': 0, 'SEMANTICSIMILARITYTABLE': 0, 'FULL': 0, 'COMPUTE': 0, 'GOTO': 0,
            'EXEC': 0, 'NATIONAL': 0, 'COMMIT': 0, 'CURRENT': 0, 'MERGE': 0, 'TRIGGER': 0, 'COLLATE': 0, 'ESCAPE': 0, 'UNIQUE': 0, 'WHERE': 0,
            'DECLARE': 0, 'PROCEDURE': 0, 'ON': 0, 'DOUBLE': 0, 'CONTAINS': 0, 'PRIMARY': 0, 'CURSOR': 0, 'ROWCOUNT': 0, 'RAISERROR': 0,
            'VALUES': 0, 'ROWGUIDCOL': 0, 'OF': 0, 'RESTORE': 0, 'OR': 0, 'DELETE': 0, 'INDEX': 0, 'CONVERT': 0, 'GROUP': 0, 'TRUNCATE': 0,
            'TSEQUAL': 0, 'SOME': 0, 'FOREIGN': 0, 'RESTRICT': 0, 'CURRENT_TIMESTAMP': 0, 'USER': 0, 'CURRENT_USER': 0, 'PRINT': 0, 'ROLLBACK': 0,
            'SELECT': 0, 'BEGIN': 0, 'IDENTITYCOL': 0, "'": 0, 'DISTINCT': 0, '+': 0, 'NOCHECK': 0, 'ALTER': 0, 'COALESCE': 0, 'SETUSER': 0,
            'ORDER': 0, 'DEALLOCATE': 0, 'IS': 0, 'FUNCTION': 0, 'END': 0, 'FOR': 0, 'UNION': 0, 'VARYING': 0, 'UPDATE': 0, 'ELSE': 0, '"': 0,
            'EXTERNAL': 0, 'UPDATETEXT': 0, 'IDENTITY': 0, 'AND': 0, 'WRITETEXT': 0, 'SAVE': 0, 'HOLDLOCK': 0, 'OFFSETS': 0, 'PRECISION': 0,
            '|': 0, 'CHECKPOINT': 0, 'CONTINUE': 0, 'NOT': 0, '{': 0, 'VIEW': 0, 'PROC': 0, 'ANY': 0, 'PLAN': 0, 'CURRENT_TIME': 0, '*': 0,
            'OPTION': 0, 'DUMP': 0, 'FREETEXT': 0, 'DEFAULT': 0, 'CONTAINSTABLE': 0, 'CROSS': 0, 'BULK': 0, 'WHILE': 0, 'REFERENCES': 0,
            'RETURN': 0, 'OPEN': 0, 'FETCH': 0, 'CASE': 0, 'SEMANTICKEYPHRASETABLE': 0, 'SET': 0, 'SECURITYAUDIT': 0, 'COLUMN': 0, 'DROP': 0,
            'REVERT': 0, 'RULE': 0, 'ASC': 0, 'AUTHORIZATION': 0, 'CLOSE': 0, 'DESC': 0, 'DBCC': 0, 'LEFT': 0, 'OUTER': 0, 'DISTRIBUTED': 0,
            'CASCADE': 0, 'ADD': 0, 'ERRLVL': 0, 'ALL': 0, 'STATISTICS': 0, 'JOIN': 0, 'LIKE': 0, 'DATABASE': 0, 'NULLIF': 0, 'TRAN': 0,
            'OPENQUERY': 0, 'BREAK': 0, 'EXIT': 0, 'KEY': 0, '}': 0, 'PIVOT': 0, 'SCHEMA': 0, 'PUBLIC': 0, 'TRY_CONVERT': 0, 'USE': 0,
            'REVOKE': 0, 'OPENDATASOURCE': 0, 'TOP': 0, 'WAITFOR': 0, 'SHUTDOWN': 0, 'OFF': 0, 'DISK': 0, 'INSERT': 0, 'NULL': 0, 'CONSTRAINT': 0,
            'BROWSE': 0, 'CREATE': 0, 'GRANT': 0, 'WHEN': 0, 'SEMANTICSIMILARITYDETAILSTABLE': 0, 'TO': 0, 'UNPIVOT': 0, 'RECONFIGURE': 0,
            'IDENTITY_INSERT': 0, 'EXISTS': 0, 'PERCENT': 0, 'INTO': 0, 'DENY': 0, 'AS': 0, 'INNER': 0, 'INTERSECT': 0, 'IN': 0, 'IF': 0,
            'TABLESAMPLE': 0, 'RIGHT': 0, 'FROM': 0, 'TEXTSIZE': 0, 'OPENXML': 0, 'WITHIN GROUP': 0, 'FILLFACTOR': 0, 'LINENO': 0, 'CLUSTERED': 0,
            'BACKUP': 0, 'HAVING': 0}


def convert_uri(uri):
    new_uri = ''

    try:
        for index, sub_uri in enumerate(uri.split('%')):
            if sub_uri:
                if index == 0:
                    new_uri = sub_uri
                    continue

                try:
                    hex_val = bytearray.fromhex(sub_uri[:2]).decode()
                except UnicodeDecodeError:
                    hex_val = ''
                except ValueError:
                    print(uri + ' --- ' + sub_uri[:2])
                    return ''
                except Exception as e:
                    print(str(e))
                    print(uri + '---' + sub_uri[:2])
                    exit(0)

                new_uri += hex_val + sub_uri[2:]

        new_uri = new_uri.upper()

    except:
        pass

    return new_uri


def uri_to_features(uri):

    global keywords
    global keywords_list

    uri = convert_uri(uri)

    keywords_aux = keywords.copy()
    ok = False

    try:
        for keys in keywords_aux:
            if keys in uri:
                if keywords_list.index(keys) > 184:
                    keywords_aux[keys] = uri.count(keys)
                    if not uri.count(keys) == 0:
                        ok = True
                else:
                    sub_uri = uri.split(keys)
                    for index, ele in enumerate(sub_uri):
                        if index + 1 < len(sub_uri):
                            if ele and sub_uri[index + 1]:
                                if not ele[-1].isalpha() and not sub_uri[index+1][0].isalpha():
                                    keywords_aux[keys] += 1
                                    ok = True
                        else:
                            if not ele and sub_uri[index - 1]:
                                    keywords_aux[keys] += 1
                                    ok = True
    except:
        ok = False

    if ok:
        features = {}
        for keys in keywords_list:
            if not keywords_aux[keys] == 0:
                features[keywords_list.index(keys)+1] = keywords_aux[keys]
        keywords_aux.clear()
        return features
    else:
        keywords_aux.clear()
        return {}





def main(argv):

    parser = argparse.ArgumentParser()
    parser.add_argument('-u', type=str, help='uri to be converted')

    args = parser.parse_args(argv[1:])

    if not args.u:
        print('No given string(uri)')
        exit(0)

    uri = convert_uri(args.u)

    print(uri)


if __name__ == '__main__':
    main(sys.argv)
